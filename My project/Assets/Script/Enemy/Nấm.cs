using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Nấm : MonoBehaviour
{
    // Move
    [SerializeField] private float left;
    [SerializeField] private float right;
    [SerializeField] private float jumpLength;
    // SPine Animation
   [SpineAnimation] public string idleAnimationName;
   [SpineAnimation] public string dieAnimationName;
    [SpineAnimation] public string jumpAnimationName;
   SkeletonAnimation skeletonAnimation;
    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;

    private Rigidbody2D rb;
    private Collider2D coll;
    private bool facingLeft = true;
     public bool goLeft = true;
    public bool goRight = true;
    private bool canMove = true;
    public bool isMove;
    public Transform endPoint;
    private void Start() {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }
    private void Update() {
        if(canMove && isMove){
            Move();
        }
    }
     private void Move(){
        if(facingLeft){
            
            if(transform.position.x > left){
                if(transform.localScale.x != 0.2f ){
                    transform.localScale = new Vector3(0.2f, 0.2f);
                }
                        if(goLeft){
                            StartCoroutine(jumpLeft());
                            goLeft = false;
                        }
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
                    if(goRight){
                    StartCoroutine(jumpRight());    
                    goRight = false;
                    }
                }
            else{
                facingLeft = true;
            }
        }
    }
     IEnumerator jumpLeft(){
           
            spineAnimationState.SetAnimation(1, idleAnimationName, false);
            spineAnimationState.AddAnimation(1, jumpAnimationName, false, 0);
             yield return new WaitForSeconds(1.2f);
             rb.velocity = new Vector2(-jumpLength, 0);
            yield return new WaitForSeconds(.2f);
            goLeft = true;
           
    }
    IEnumerator jumpRight(){
            
            spineAnimationState.SetAnimation(1, idleAnimationName, false);
            spineAnimationState.AddAnimation(1, jumpAnimationName, false, 0);
             yield return new WaitForSeconds(1.2f);
             rb.velocity = new Vector2(jumpLength, 0);
            yield return new WaitForSeconds(.2f);
            goRight = true;
            
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("foot")){
            if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
                BgSound.Instance.PlayHit();
            }
            PlayerController.instance.DisableRigibody();
            PlayerController.instance.EnableRigigbody();
            FolowRoute.ins.JumpToEnd(endPoint);
            canMove = false;
            DieToNormal();
            rb.mass = 10;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            PlayerController.instance.Die();
        }
        if(other.gameObject.CompareTag("PlayerAI")){
            PlayerAI.instance.Die();
        }
    }
    public void DieToNormal(){
        spineAnimationState.SetAnimation(1,dieAnimationName, false);
        spineAnimationState.AddAnimation(1,idleAnimationName, true, 0);
    }
}
