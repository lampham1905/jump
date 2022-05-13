using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public GameObject GamePlayPanel;
    public GameObject VictoryPanel;
    public GameObject DeadPanel;
    public GameObject PausePanel;
    public static GameUIManager instance;
    private void Awake() {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GamePlayPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowVictoryPanel(){
        VictoryPanel.SetActive(true);
        GamePlayPanel.SetActive(false);
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
    void ResumeGame(){
       Time.timeScale = 1; 
    }
}
