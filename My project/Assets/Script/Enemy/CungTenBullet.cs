using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CungTenBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyBullet());
    }

     void Update()
    {
        //transform.Translate(Vector3.up * 5 * Time.deltaTime);
        rb.velocity = new Vector2(0, 6);
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "DestroyBullet")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("PlayerAI")){
            Destroy(gameObject);
        }
    }
    IEnumerator DestroyBullet(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
