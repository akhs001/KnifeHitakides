using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : Singleton<Message>
{
    private readonly Text messageTextUI;
    private readonly GameObject messagePanelUI;

    public Message(GameObject panel )
    {
        messagePanelUI = panel;
        messageTextUI = messagePanelUI.GetComponentInChildren<Text>();
    }
    
    public void ShowMessage(string _message)
    {
        messagePanelUI.SetActive(true);
        messageTextUI.text = _message;
    }
    
}
