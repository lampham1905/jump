using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomeGUI : MonoBehaviour
{
    public static HomeGUI instance;
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    public GameObject HomePanel;
    public GameObject SettingPanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CheckHideSettingPanel();
    }
    public void ShowSettingPanel(){
        BgSound.Instance.PlayTap();
        SettingPanel.SetActive(true);
        HomePanel.SetActive(false);
       
        Time.timeScale = 0;
    }
    public void HideSettingsPanel(){
        BgSound.Instance.PlayTap();
        SettingPanel.SetActive(false);
        HomePanel.SetActive(true);
     
        Time.timeScale = 1;
    }
   
   
}
