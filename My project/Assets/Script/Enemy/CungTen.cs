using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CungTen : MonoBehaviour
{
    public GameObject CungTenPrefab;
    public Transform firePoint;
    public bool isShooting = true;
    public bool isStartShooting = false;
    private void Start() {
        if(isStartShooting){
            StartCoroutine(CungTenCoroutine());
        }
    }
    IEnumerator CungTenCoroutine(){
        while(isShooting){
            yield return new WaitForSeconds(1f);
            Shoot();
            yield return new WaitForSeconds(2f);
        }
    }
    private void Shoot(){
        Instantiate(CungTenPrefab, firePoint.position, firePoint.rotation);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("MainCamera")){
            Debug.LogWarning("Triggering");
            isShooting = true;
            StartCoroutine(CungTenCoroutine());
        }
    }
}
