using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed;
    //private Rigidbody2D rb;
    // Start is called before the first frame update
    private bool isMoveUp = true;
    private bool isMoveLeft = true;
    public float  bottomPoint;
    public float topPoint;
    public float leftPoint;
    public float rightPoint;
    public bool IsMoveUpDown = false;
    public bool IsMoveLeftRight = false;
    public bool canMove = false;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
       

    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            if(IsMoveUpDown){
            MoveUpDown();
        }
        if(IsMoveLeftRight){
            MoveLeftRight();
        }
        }
    }
    private  void MoveUpDown(){
        if(isMoveUp){
            if(transform.position.y > bottomPoint){
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else{
                isMoveUp = false;
            }
        }
        else{
            if(transform.position.y < topPoint){
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                  
            }
            else{
                isMoveUp = true;
            }
    }
    }
    private void MoveLeftRight(){
        if(isMoveLeft){
            if(transform.position.x > leftPoint){
                //rb.velocity = new Vector2(-speed, 0);
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else{
                isMoveLeft = false;
            }
        }
        else{
            if(transform.position.x < rightPoint){
                //rb.velocity = new Vector2(speed, 0);
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else{
                isMoveLeft = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject. CompareTag("MainCamera")){
            canMove = true;
        }
    }
}
