using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingBtn : Button
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public override void OnPointerDown(PointerEventData eventData)
    {
        BgSound.Instance.PlayTap();
        base.OnPointerDown(eventData);
        Time.timeScale = 0;
        GameUIManager.instance.ShowSettingPanel();
        //PlayerController.instance.canJump = true;
    }
}
