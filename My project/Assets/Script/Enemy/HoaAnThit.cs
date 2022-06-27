using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class HoaAnThit : MonoBehaviour
{
    #region Inspector
    [Header("Animation")]
    [SpineAnimation] public string idleAnimationName;
    [SpineAnimation] public string attackAnimationName;

    #endregion
    // Spine
    SkeletonAnimation skeletonAnimation;
    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;
    public bool attack = true;
    public GameObject LuoiHoa;
    private void Start() {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
        //StartCoroutine(AttackCoroutine());
    }
    private void Update() {
        if(attack){
            StartCoroutine(AttackCoroutine());
            attack = false;
        }
    }
    IEnumerator AttackCoroutine() {
        spineAnimationState.SetAnimation(0, idleAnimationName, true );
        yield return new WaitForSeconds(1f);
        spineAnimationState.SetAnimation(0, attackAnimationName, false);
        yield return new WaitForSeconds(.6f);
        LuoiHoa.SetActive(true);
        yield return new WaitForSeconds(.6f);
        LuoiHoa.SetActive(false);
        attack = true;
    }
   
}
