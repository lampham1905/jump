using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerComplete();
    }
    private void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.CompareTag("end")){
            if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
            BgSound.Instance.PlayDie();
            GameUIManager.instance.ShowDeadPanel();

        }
           // PlayerController.instance.NextLevel();
            PlayerAI.instance.isCompelete = true;
       }
        // if(other.gameObject.CompareTag("nextPlatform")){
        //     PlayerController.instance.NextPlatform();
        // }
        // if(other.gameObject.CompareTag("jumpHalf")){
        //     GameUIManager.instance.ShowLeftWind();
        // }
        // if(other.gameObject.CompareTag("jumpFull")){
        //     GameUIManager.instance.ShowRightWind();
        // }
    }
    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.CompareTag("end")){
    //         PlayerController.instance.NextLevel();
    //         SaveData.instance.AddLevelAndSave();
    //     }
    // }
    public void CheckPlayerComplete(){
        if(GameManager.instance.isCompelete){
            Destroy(this.gameObject);
    }}
}
