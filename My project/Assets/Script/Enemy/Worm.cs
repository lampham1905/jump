using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Worm : MonoBehaviour
{
     #region Inspector
     [Header("Animation")]
     [SpineAnimation] public string idleAnimationName;
     [SpineAnimation] public string attackAnimationName;
     #endregion
     public bool attack = true;
     public bool isAttack = true;
     public GameObject worm;
     SkeletonAnimation skeletonAnimation;
    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;
     IEnumerator AttackCoroutine() {
        spineAnimationState.SetAnimation(0, idleAnimationName, true );
        yield return new WaitForSeconds(1f);
        spineAnimationState.SetAnimation(0, attackAnimationName, false);
        yield return new WaitForSeconds(.8f);
        worm.SetActive(true);
        yield return new WaitForSeconds(.4f);
        worm.SetActive(false);
        attack = true;
    }
     private void Update() {
        if(attack){
            StartCoroutine(AttackCoroutine());
            attack = false;
        }
    }
    private void Start() {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
        //StartCoroutine(AttackCoroutine());
    }
}
