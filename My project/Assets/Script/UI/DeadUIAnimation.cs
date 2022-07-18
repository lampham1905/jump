using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class DeadUIAnimation : MonoBehaviour
{
    public static DeadUIAnimation ins;
     public SkeletonGraphic skeletonGraphic;
    public Spine.AnimationState spineAnimationState;
    [SpineAnimation] public string startAnimationName;
    [SpineAnimation] public string idleAnimationName;
    private void Awake() {
        ins = this;
        skeletonGraphic = GetComponent<SkeletonGraphic>();
        spineAnimationState  = skeletonGraphic.AnimationState;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartAnimation(){
        spineAnimationState.SetAnimation(0, startAnimationName, false);
        spineAnimationState.AddAnimation(0, idleAnimationName, true, 0);
    }
}
