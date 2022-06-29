using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    public static HomeManager instance;
    private void Awake() {
        instance = this;
    }
    public void LoadSceneCurrent(){
        
        if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
            BgSound.Instance.PlayTap();
        }
        int LevelCur = PlayerPrefs.GetInt("levelCur", 1);
        //SceneManager.LoadScene("level" + LevelCur);
        SceneManager.LoadScene("level20");
        PlayerPrefs.SetInt("Mode", 0);
        PlayerPrefs.Save();
    }
    public void LoadSceneAICurrent(){
        if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
            BgSound.Instance.PlayTap();
            }
        int LevelAICur = PlayerPrefs.GetInt("levelCurAI", 1);
        //SceneManager.LoadScene("level" + LevelAICur);
         SceneManager.LoadScene("level14");
        PlayerPrefs.SetInt("Mode", 1);
        PlayerPrefs.Save();
    }
}
