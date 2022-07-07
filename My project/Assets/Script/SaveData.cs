using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public  class SaveData : MonoBehaviour
{   
    public static SaveData instance;
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
    }
    public int levelCur;
    public int levelCurAI;
      
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
         AddLevelAndSave();
         AddLevelAndSaveAI();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Mode: " + PlayerPrefs.GetInt("Mode"));
        //Debug.Log(PlayerPrefs.GetInt("levelCurAI"));
    }
    public void AddLevelAndSave(){
       if(PlayerPrefs.GetInt("Mode") == 0){
            levelCur = PlayerPrefs.GetInt("levelCur", 0);
            if(levelCur < SceneManager.GetActiveScene().buildIndex){
                levelCur = SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("levelCur", levelCur);
                PlayerPrefs.Save();
        }
        
       }
    }
    public void AddLevelAndSaveAI(){
        if(PlayerPrefs.GetInt("Mode") == 1){
            levelCurAI = PlayerPrefs.GetInt("levelCurAI", 0);
            if(levelCurAI < SceneManager.GetActiveScene().buildIndex){
                levelCurAI = SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("levelCurAI", levelCurAI);
                PlayerPrefs.Save();
            }
        }
    }
    public void CheckMusicOn(){
        
    }

}
