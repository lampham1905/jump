using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class PhuThuy : MonoBehaviour
{
     #region Inspector
     public Transform firePoint;
     public GameObject bulletPrefab;
     [Header("Animation")]
     [SpineAnimation] public string idleAnimationName;
     [SpineAnimation] public string attackAnimatioName;
     #endregion

     //Spine Animation
     SkeletonAnimation skeletonAnimation;
    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;
    public bool isShooting = false;

    private void Start() {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
        StartShoot();
    }
    private void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    IEnumerator ShootingCoroutine(){
        while(isShooting){
            spineAnimationState.SetAnimation(0, attackAnimatioName, false);
            spineAnimationState.AddAnimation(0, idleAnimationName, true, 0);
            yield return new WaitForSeconds(.8f);
            Shoot();
            yield return new WaitForSeconds(1.2f);
        }
    }
    private void StartShoot(){
        StartCoroutine(ShootingCoroutine());
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("MainCamera")){
            isShooting = true;
            StartShoot();
        }
    }
    private void Update() {
        
    }
}
