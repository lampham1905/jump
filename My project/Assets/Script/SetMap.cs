using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMap : MonoBehaviour
{
    public static SetMap ins;
    private void Awake() {
        ins = this;
    }
    public GameObject platFormStart;
    public GameObject platFormFull;
    public GameObject platFormHalf;
    public Transform currPlatForm;
    public Transform StartPlatformPos;
   public void Set(){
        currPlatForm = StartPlatformPos;
       int[] set = {0, 1, 2, 2};
       for(int i = 0; i < set.Length; i++){
            if(set[i] == 0){
                Instantiate(platFormStart, currPlatForm.position, Quaternion.identity);
            }
            else if(set[i] == 1){
                Instantiate(platFormFull, currPlatForm.position, Quaternion.identity);
            }
            else if(set[i] == 2){
                Instantiate(platFormHalf, currPlatForm.position, Quaternion.identity);
            }
            currPlatForm.position = new Vector2(currPlatForm.position.x +5f, currPlatForm.position.y);
        }
   }
}
