using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomeGUI : MonoBehaviour
{
    public static HomeGUI instance;
    public GameObject MusicOff;
    public GameObject SoundOff;
    public GameObject Theme1;
    public GameObject Theme2;
    public GameObject Theme3;
    public GameObject Theme4;

    private void Awake() {
       instance = this;
       int levelCur = PlayerPrefs.GetInt("LeveCur");
       
    }
    // Start is called before the first frame update
    public GameObject HomePanel;
    public GameObject SettingPanel;
    public GameObject ModePanel;
    public GameObject LevelPanel;
    int levelCur;
   
    void Start()
    {
        CheckMusicStart();
        CheckSoundStart();
        PlayerPrefs.DeleteAll();
        //PlayerPrefs.DeleteAll();
        // PlayerPrefs.SetInt("levelCur", 28);
        // PlayerPrefs.Save();

        if(PlayerPrefs.GetInt("levelCur") == 0){
            levelCur = 1;
        }
        else
        {levelCur = PlayerPrefs.GetInt("levelCur");}   
        Debug.Log(levelCur);
         if( levelCur >= 1 && levelCur <= 15) {
            Theme1.SetActive(true);
            Theme2.SetActive(false);
            Theme3.SetActive(false);  
        }
        else if(levelCur > 15 && levelCur <= 25){
            Theme1.SetActive(false);
            Theme2.SetActive(true);
            Theme3.SetActive(false);  
        }
         else if(levelCur > 25 && levelCur <= 35){
            Theme1.SetActive(false);
            Theme2.SetActive(false);
            Theme3.SetActive(true);  
        }
         else if(levelCur > 35 && levelCur <= 45){
            Theme1.SetActive(false);
            Theme2.SetActive(false);
            Theme3.SetActive(false);
            Theme4.SetActive(true);  
        }
    }

    // Update is called once per frame
    void Update()
    {
        //CheckHideSettingPanel();
    }
    public void ShowSettingPanel(){
         if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
            BgSound.Instance.PlayTap();
        }
        SettingPanel.SetActive(true);
        HomePanel.SetActive(false);
       
        Time.timeScale = 0;
    }
    public void HideSettingsPanel(){
         if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
            BgSound.Instance.PlayTap();
        }
        SettingPanel.SetActive(false);
        HomePanel.SetActive(true);
     
        Time.timeScale = 1;
    }
   public void TurnOffMusic(){
       int isMusicOn = PlayerPrefs.GetInt("isMusicOn", 1);
       if(isMusicOn == 1){
            MusicOff.SetActive(true);
            BgSound.Instance.PauseMusic();
            PlayerPrefs.SetInt("isMusicOn", 0);
            PlayerPrefs.Save();
       }
       if(isMusicOn == 0){
            MusicOff.SetActive(false);
            BgSound.Instance.PlayMusic();
            PlayerPrefs.SetInt("isMusicOn", 1);
            PlayerPrefs.Save();
       }
   }
   public void CheckMusicStart(){
       if(PlayerPrefs.GetInt("isMusicOn", 1) == 1){
           BgSound.Instance.PlayMusic();
            MusicOff.SetActive(false);
       }
       else{
              MusicOff.SetActive(true);
       }
       
   }
   public void TurnOffSound(){
         int isSoundOn = PlayerPrefs.GetInt("isSoundOn", 1);
         if(isSoundOn == 1){
            SoundOff.SetActive(true);
            PlayerPrefs.SetInt("isSoundOn", 0);
            PlayerPrefs.Save();
         }
         if(isSoundOn == 0){
            SoundOff.SetActive(false);
            PlayerPrefs.SetInt("isSoundOn", 1);
            PlayerPrefs.Save();
         }
   }
   public void CheckSoundStart(){
         if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
            SoundOff.SetActive(false);
         }
         else{
             SoundOff.SetActive(true);
         }
   }
   public void EasyLevel(){
        PlayerPrefs.SetInt("dokho", 0); 
        PlayerPrefs.Save(); 
        HomeManager.instance.LoadSceneAICurrent();

   }
   public void DifficultLevel(){
        PlayerPrefs.SetInt("dokho", 1); 
        PlayerPrefs.Save();
        HomeManager.instance.LoadSceneAICurrent();
   }
   public void ShowModePanel(){
         if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
            BgSound.Instance.PlayTap();
        }
        ModePanel.SetActive(true);
        HomePanel.SetActive(false);
        
   }
   public void HideModePanel(){
         if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
            BgSound.Instance.PlayTap();
        }
        ModePanel.SetActive(false);
        HomePanel.SetActive(true);
}
    public void ShowLevelPanel(){
            if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
                BgSound.Instance.PlayTap();
            }
            LevelPanel.SetActive(true);
            ModePanel.SetActive(false);
    }
    public void HideLevelPanel(){
            if(PlayerPrefs.GetInt("isSoundOn", 1) == 1){
                BgSound.Instance.PlayTap();
            }
            LevelPanel.SetActive(false);
            ModePanel.SetActive(true);
    }
  
}
