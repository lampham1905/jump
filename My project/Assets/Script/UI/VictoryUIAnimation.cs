using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class VictoryUIAnimation : MonoBehaviour
{
    public static VictoryUIAnimation ins;
    private void Awake() {
        ins = this;
         skeletonGraphic = GetComponent<SkeletonGraphic>();
        spineAnimationState  = skeletonGraphic.AnimationState;
    }
    public SkeletonGraphic skeletonGraphic;
    public Spine.AnimationState spineAnimationState;
	
     
    [SpineAnimation] public string startAnimationName;
    [SpineAnimation] public string idleAnimationName;
    // Start is called before the first frame update
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.Debug.Log(spineAnimationState);

    //     var state = skeletonGraphic.AnimationState;
    //    UnityEngine.Debug.Log(state.GetCurrent(0));
    }

    public void StartAnimation(){
        spineAnimationState.SetAnimation(1, startAnimationName, false);
        spineAnimationState.AddAnimation(1, idleAnimationName, true, 0);
    }
  
} 
