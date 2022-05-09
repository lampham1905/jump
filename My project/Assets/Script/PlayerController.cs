using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Spine.Unity;
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
    }
    [Header("Animation")]
    [SpineAnimation] public string idleAnimationName;
    [SpineAnimation] public string dieAnimationName;
    [SpineAnimation] public string holdAnimationName;
    [SpineAnimation] public string jumpStartAnimationName;
    [SpineAnimation] public string jumpUpAnimationName;
    [SpineAnimation] public string jumpDownAnimationName;
    [SpineAnimation] public string jumpEndAnimationName;


    [Header("Movement")]
    public Vector2 jumpForce;
    public Vector2 jumpForceUp;
     public float minForceX;
    public float maxForceX;
    public float minForceY;
    public float maxForceY;
    public AnimationCurve curve;
    
    
    
    // Set power
    bool m_didJump;
    bool m_didJumpDown;
    bool m_powerSetted;
    bool maxPower;
    public bool jumpFull = true;

    //Parabola
    public float h = 25;
    public float gravity = -18;
    private Rigidbody2D rb;
    private Collider2D coll;
    public float currPowerBarVal = 0;
    public string nextScene;
    private LineRenderer lr;
    //private Renderer rend;
     public float displacementY;
     public float forceX;

     // Spine Region
     SkeletonAnimation skeletonAnimation;
     public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        lr = GetComponent<LineRenderer>();
        // rend = GetComponent<Renderer>();
        // rend.material.mainTextureScale =
        //   new Vector2(Vector2.Distance(lr.GetPosition(0), lr.GetPosition(lr.positionCount - 1)) / lr.widthMultiplier,1);
        //Spine animation
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
    SetPower();
    if(Input.GetMouseButtonDown(0)){
            SetPower(true);
            spineAnimationState.SetAnimation(0, holdAnimationName, false);
        }
    if(Input.GetMouseButtonUp(0)){
            SetPower(false);
            lr.positionCount = 0;
            spineAnimationState.SetAnimation(0, jumpStartAnimationName, false);
            spineAnimationState.AddAnimation(0, jumpUpAnimationName, false, 0);
        }
    
        // rend.material.mainTextureScale =
        //   new Vector2(Vector2.Distance(lr.GetPosition(0), lr.GetPosition(lr.positionCount - 1)) / lr.widthMultiplier,1);
    lr.material.mainTextureScale = new Vector2(1f / lr.startWidth, 1.0f);
    checkAnimationJump();
    CheckJumpEnemy();

#endif
    }
    void fixedUpdate(){
        
    }
    void SetPower()
    {
        if(jumpFull){
            minForceX = 2.5f;
            maxForceX = 4.5f;
            minForceY = 3f;
            maxForceY = 13f;
        }
        else{
            minForceX = .7f;
            maxForceX = 2.7f;
            minForceY = 1f;
            maxForceY = 11f;

        }
        forceX = jumpForce.x;
        if (m_powerSetted && !m_didJump)
        {
            //m_powerJumpX = jumpForce.x;
            if(jumpForce.x == maxForceX) maxPower = true;
            if(jumpForce.x == minForceX) maxPower = false;
            if(maxPower == false){
                //Effect by wind
                //jumpForce.x += jumpForceUp.x * Time.deltaTime + speedWind/300;

                // Not effect by wind
                jumpForce.x += jumpForceUp.x * Time.deltaTime/1.5f;
                jumpForce.y += jumpForceUp.y * Time.deltaTime/1.5f;
                jumpForce.x = Mathf.Clamp(jumpForce.x, minForceX, maxForceX);
                jumpForce.y = Mathf.Clamp(jumpForce.y, minForceY, maxForceY);
            }

            if(maxPower){
                // Effect by wind
                //jumpForce.x -= jumpForceUp.x * Time.deltaTime + speedWind/300;

                // Not effect by wind
                jumpForce.x -= jumpForceUp.x * Time.deltaTime/1.5f;
                jumpForce.y -= jumpForceUp.y * Time.deltaTime/1.5f;
                jumpForce.x = Mathf.Clamp(jumpForce.x, minForceX, maxForceX);
                jumpForce.y = Mathf.Clamp(jumpForce.y, minForceY, maxForceY);
            }
                           
           



            // tranjectory line
            Vector2 StartTranjectory = new Vector2(transform.position.x, transform.position.y + .5f);
            Vector2[] tranjectory = Plot(rb, StartTranjectory, jumpForce, 1000);
            lr.positionCount = tranjectory.Length;
            Vector3[] positions = new Vector3[tranjectory.Length];
            for(int i = 0; i < tranjectory.Length; i++)
            {
                positions[i] = tranjectory[i];
            }
            lr.SetPositions(positions);
           
            float width = lr.startWidth;
            //lr.material.mainTextureScale = new Vector2(1f / lr.startWidth, 1.0f);

        }
    }
     public  Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps){
        Vector2[] results = new Vector2 [steps];

        float timestep = Time.fixedDeltaTime/ Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * timestep * timestep;

        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;
        for(int i = 0; i < steps; i++){
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }
        return results;
    }

      public void SetPower(bool isHoldingMosue)
    {
        m_powerSetted = isHoldingMosue;

        if(!m_powerSetted && !m_didJump)
        {
            Jump();
        }
    }
     void Jump()
    {
        if (!rb || jumpForce.x <= 0 || jumpForce.y <= 0) return;

        rb.velocity = jumpForce;

        m_didJump = true;

        // if (m_anim)
        // {
        //     anim.SetBool("didJump", true);
        // }
    }
    // check animation when jump
    private void checkAnimationJump(){
        if(m_didJump){
            if(rb.velocity.y < 0){
                spineAnimationState.SetAnimation(0, jumpDownAnimationName, false);
                m_didJumpDown = true;
            }
        }
        if(m_didJumpDown){
            if (!m_didJump){
                spineAnimationState.SetAnimation(0, jumpEndAnimationName, false);
                spineAnimationState.AddAnimation(0,idleAnimationName, true, 0);
                m_didJumpDown = false;
            }
        }
    }
    IEnumerator AnimationJumpDown(){
        yield return new WaitForSeconds(.233f);
        spineAnimationState.SetAnimation(0, idleAnimationName, true);

    }
    public void CheckJumpEnemy(){
        if(GameManager.instance.isJumpingEnemy){
            int layerPlatform = 3;
            int layerMaskPLatformat = 1 << layerPlatform;
           RaycastHit2D hitBottom = Physics2D.Raycast(transform.position, Vector2.down, 1f, layerMaskPLatformat);
           if(hitBottom.collider != null && hitBottom.collider.CompareTag("Ground")){
                GameManager.instance.isJumpingEnemy = false;
                if(GameManager.instance.endPoint.Length > GameManager.instance.currEndPoint + 1){
                     GameManager.instance.currEndPoint++;
                }
                else{
                    return;
                }
            }
    }}
    
 
    
   
    
 
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag  == "Ground"){
            if(m_didJump){
                m_didJump = false;
                if(rb){
                rb.velocity = Vector2.zero;
                }
                jumpForce = Vector2.zero;
                currPowerBarVal = 0;
            }
        }    
        if(other.gameObject.tag == "Die"){
            Die();
            //StartCoroutine(DieCouroutine());
        }
    //    if(other.gameObject.CompareTag("endPoint")){
    //         if(GameManager.instance.endPoint.Length > GameManager.instance.currEndPoint + 1){
    //             GameManager.instance.currEndPoint++;
    //         }
    //         else{
    //             return;
    //         }
    //     }
       
    }
    IEnumerator DieCouroutine(){
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
     private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.tag == "nextPlatform"){
            CamController.instance.LerpTrigeer(transform.position.x + 1.8f);
        }    
        if(other.gameObject.tag == "jumpHalf"){
            jumpFull = false;
        }
        if(other.gameObject.tag == "jumpFull"){
            jumpFull = true;
        }
        if(other.gameObject.tag == "end"){
            NextScene(nextScene);
        }
        if(other.gameObject.CompareTag("Die")){
            Die();
            
        }
         
    }
    
    public void DisableRigibody(){
        rb.bodyType = RigidbodyType2D.Static;
    }
    public void InvokeEnableRigigbody(){
    
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void EnableRigigbody(){
        Invoke("InvokeEnableRigigbody", 1f);
    }
    private void NextScene(string nextScene){
        SceneManager.LoadScene(nextScene);
    }
    public void Die(){
        rb.velocity = new Vector2(0, 5f);
        coll.enabled = false;
        spineAnimationState.SetAnimation(0, dieAnimationName, false);
        StartCoroutine(DieCouroutine());
    }

}
