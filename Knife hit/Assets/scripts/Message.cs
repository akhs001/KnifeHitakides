using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : Singleton<Message>
{
    private  Text messageTextUI;
    public GameObject messagePanelUI;
    public bool IsShown;

    public void Start()
    {
        messageTextUI = messagePanelUI.GetComponentInChildren<Text>();
    }

    public void NotShown() => IsShown=false;
    
    public void ShowMessage(string _message)
    {
        IsShown = true;
        messagePanelUI.SetActive(true);
        messageTextUI.text = _message;
    }
    
}
