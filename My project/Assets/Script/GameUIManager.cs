using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameUIManager : MonoBehaviour
{
    public GameObject GamePlayPanel;
    public GameObject VictoryPanel;
    public GameObject DeadPanel;
    public GameObject PausePanel;
    public GameObject SettingPanel;
    public GameObject LeftWind;
    public GameObject RightWind;
    public static GameUIManager instance;
     bool isShowSettingPanel = false;
     public TextMeshProUGUI LevelText;
    private void Awake() {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        GamePlayPanel.SetActive(true);
        LevelText.text = "LEVEL " + (SceneManager.GetActiveScene().buildIndex).ToString();
    }

    // Update is called once per frame
   
    public void ShowVictoryPanel(){
        VictoryPanel.SetActive(true);
        GamePlayPanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void ShowDeadPanel(){
        DeadPanel.SetActive(true);
        GamePlayPanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void ShowPausePanel(){
        PausePanel.SetActive(true);
        GamePlayPanel.SetActive(false);
        PlayerController.instance.canJump = false;
    }
    public void HidePauseGamePanel(){
         PausePanel.SetActive(false);
        GamePlayPanel.SetActive(true);
       Invoke("ResumeGame", 0.01f);
    }
    //  void CanJumpCounters(){
    //     PlayerController.instance.canJump = true;
    // }
    public void ShowSettingPanel(){
    
        SettingPanel.SetActive(true);
        GamePlayPanel.SetActive(false);
       

    }
    public void HideSettingsPanel(){
        SettingPanel.SetActive(false);
        GamePlayPanel.SetActive(true);
    }
   
    void ResumeGame(){
       Time.timeScale = 1; 
    }
    public void ShowLeftWind(){
        LeftWind.SetActive(true);
        RightWind.SetActive(false);
    }
    public void ShowRightWind(){
        LeftWind.SetActive(false);
        RightWind.SetActive(true);
    }
}
