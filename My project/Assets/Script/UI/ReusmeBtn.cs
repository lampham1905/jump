using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ReusmeBtn : Button
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
        
        base.OnPointerDown(eventData);
        BgSound.Instance.PlayTap();
        GameUIManager.instance.HidePauseGamePanel();
        Time.timeScale = 1;
        //PlayerController.instance.canJump = true;
    }
}
