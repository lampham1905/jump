using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Alien1 : MonoBehaviour
{
   #region Inspector
   [Header("Animation")]
   [SpineAnimation] public string idleNormalAnimationName;
   [SpineAnimation] public string moveAnimationName;
   [SpineAnimation] public string dieAnimationName;

     [Header("PointMove")] 
    [SerializeField] private float left;
    [SerializeField] private float right;
    [SerializeField] private float speed = 5f;
   #endregion

   private Rigidbody2D rb;
   private bool facingLeft = true;
   public bool canMove;
   public Transform endPoint;

    SkeletonAnimation skeletonAnimation;
    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //SpineAnimation
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
    }
    void Update()
    {
        if(canMove){
            Move();
        }
        //spineAnimationState.SetAnimation(0, moveAnimationName, true);

    }
    private void Move(){
        if (facingLeft)
        {

            if (transform.position.x > left)
            {
                // make sure sprite is facing location, and if it is not, then face the right direction
                if (transform.localScale.x != .2f)
                {
                    transform.localScale = new Vector2(.2f, .2f);
                    //skeleton.ScaleX = .2f;
                }
                // test to see if we are on the ground, if so jump
              
                    rb.velocity = new Vector2(-speed, 0);
                    //spineAnimationState.SetAnimation(0, moveAnimationName, true);
                
            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < right)
            {
                // make sure sprite is facing location, and if it is not, then face the right direction
                if (transform.localScale.x != -.2f)
                {
                    transform.localScale = new Vector3(-.2f, .2f);
                    //skeleton.ScaleX = -.2f;
                }
                // test to see if we are on the ground, if so jump
               
                    rb.velocity = new Vector2(speed, 0);
                    //spineAnimationState.SetAnimation(0, moveAnimationName, true);
                
                   
            }
            else
            {
                facingLeft = true;
            }
        }
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
            MoveToNormal();
            //GameManager.instance.isJumpingEnemy = true;
            canMove = false;
            //rb.bodyType = RigidbodyType2D.Kinematic;
            rb.mass = 10;
        }
        else if(other.gameObject.CompareTag("footAI")){
             if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
                BgSound.Instance.PlayHit();
            }
            PlayerAI.instance.DisableRigibody();
            PlayerAI.instance.EnableRigigbody();
            FollowRouteAI.ins.JumpToEndAI(endPoint);
            MoveToNormal();
            //GameManager.instance.isJumpingEnemy = true;
            canMove = false;
            //rb.bodyType = RigidbodyType2D.Kinematic;
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
    private void MoveToNormal(){
        spineAnimationState.SetAnimation(0, dieAnimationName, false);
        spineAnimationState.AddAnimation(0, idleNormalAnimationName, true, 0);
    }
}
