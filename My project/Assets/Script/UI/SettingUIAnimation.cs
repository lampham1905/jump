using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class SettingUIAnimation : MonoBehaviour
{
    public SkeletonGraphic skeletonGraphic;
    public Spine.AnimationState spineAnimationState;
	
     
    [SpineAnimation] public string startAnimationName;
    [SpineAnimation] public string idleAnimationName;
    public static SettingUIAnimation ins;
     private void Awake() {
        ins = this;
        skeletonGraphic = GetComponent<SkeletonGraphic>();
        spineAnimationState  = skeletonGraphic.AnimationState;
    }
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
