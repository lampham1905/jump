
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class DaiBang : MonoBehaviour
{
    #region Inspector
    [Header("Animation")]
    [SpineAnimation] public string idelAnimationName;

     [SerializeField] private float left;
    [SerializeField] private float right;
    [SerializeField] private float speed = 5f;
    private bool facingLeft = true;
     SkeletonAnimation skeletonAnimation;
    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;
    #endregion
    private Rigidbody2D rb;
    private bool canMove = false;
    private void Start(){
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        //
            Move();
       // }
    }
     private void Move(){
        if(facingLeft){
            
            if(transform.position.x > left){
                if(transform.localScale.x != 0.2f ){
                    transform.localScale = new Vector3(0.2f, 0.2f);
                }
                        
                   rb.velocity = new Vector2(-speed, 0);
                          
                        
                }
            else{
                facingLeft = false;
            }
            
        }
        else{
              if(transform.position.x < right){
                
                if(transform.localScale.x != -0.2f ){
                    transform.localScale = new Vector3(-0.2f, 0.2f);
                }
                   rb.velocity = new Vector2(speed, 0);
                }
            else{
                facingLeft = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("MainCamera"))
        {
            canMove = true;
        }
    }
    
    
}
