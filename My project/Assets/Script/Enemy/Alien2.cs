using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Alien2 : MonoBehaviour
{
   #region Spector Variables
    public Transform firePoint;
    public GameObject bulletPrefab;
    [Header("Animation")]
    [SpineAnimation] public string idleNormalAnimationName;
    [SpineAnimation] public string AttackAnimationName;
    [SpineAnimation] public string DieAnimationName;
    
    #endregion

    private SkeletonAnimation skeletonAnimation;
    private Spine.AnimationState spineAnimationState;
    private Spine.Skeleton skeleton;
    public bool isShooting = false;
    public Transform endPoint;
    
    private Rigidbody2D rb;
    private Collider2D coll;
    public GameObject Warning;
     private void Start()
    {
       //StartCoroutine(AnimationCoroutine());
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }
     private void Shot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("foot")){
            if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
                BgSound.Instance.PlayHit();
            }
            PlayerController.instance.DisableRigibody();
            PlayerController.instance.EnableRigigbody();
            FolowRoute.ins.JumpToEnd(endPoint);
            GameManager.instance.isJumpingEnemy = true;
            isShooting = false;
            rb.velocity = new Vector2(0, 2f);
            //coll.enabled = false;
            spineAnimationState.SetAnimation(0, DieAnimationName, false);
            //StartCoroutine(Die());
            Warning.SetActive(false);
            spineAnimationState.AddAnimation(0, idleNormalAnimationName, true, 0);
            
           
        }
        if(other.gameObject.CompareTag("footAI")){
            if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
                BgSound.Instance.PlayHit();
            }
            PlayerAI.instance.DisableRigibody();
            PlayerAI.instance.EnableRigigbody();
            FollowRouteAI.ins.JumpToEndAI(endPoint);
            GameManager.instance.isJumpingEnemy = true;
            coll.enabled = false;
            isShooting = false;
            rb.velocity = new Vector2(0, 4f);
            spineAnimationState.SetAnimation(0, DieAnimationName, false);
            StartCoroutine(Die());
            Warning.SetActive(false);
        }
        if(other.gameObject.CompareTag("MainCamera")){
            isShooting = true;
            ShootingEnemy();
        }
    }
    public void ShootingEnemy(){
        StartCoroutine(AnimationCoroutine());
    }
    IEnumerator AnimationCoroutine(){
            while(isShooting){
                spineAnimationState.SetAnimation(0, AttackAnimationName, false);
            spineAnimationState.AddAnimation(0, idleNormalAnimationName, true, 0);
            yield return new WaitForSeconds(.8f);
            Shot();
            yield return new WaitForSeconds(1.5f);
            }
    }
    IEnumerator Die(){
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
