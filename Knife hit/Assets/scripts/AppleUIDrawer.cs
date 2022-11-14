using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleUIDrawer
{
    private readonly GameObject _panel;
    private readonly Text _text;
    private  int NumberOfApples { set; get; }
    
    public AppleUIDrawer()
    {
       _panel = GameObject.Find("AppleCounter");
       _text = _panel.GetComponentInChildren<Text>();
       //Load Apples

        NumberOfApples = PlayerPrefs.HasKey("Apples") ? PlayerPrefs.GetInt ("Apples") : 0;  

       
   
    }

    public int GetNumberOfApples()
    {
        return NumberOfApples;
    }
    
    public void Show()
    {
        _panel.SetActive(true);
    }

    public void Hide()
    {
        _panel.SetActive(false);
    }

    public void AddApples(int num)
    {
        NumberOfApples += num;
        _text.text = NumberOfApples.ToString();
    }

    public void SubApples(int num)
    {
        NumberOfApples -= num;
        _text.text = NumberOfApples.ToString();  
    }
//End class
}