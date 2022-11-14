using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class KnifeManager : IObserver
{
    public  int KnivesLeft { private set; get; }
    public int CurrentType { private set; get; }
    public GameObject CurrentKnive { set; get; }

    public bool IsLastKnive {  get=> KnivesLeft==1; }
    private readonly KnifeDrawer kniveDrawer;

    public KnifeManager(int numberOfKnives )
    {
        EventManager.StartListening(this ,"KnifeShot", DecreaseKnife ) ;
        kniveDrawer = new KnifeDrawer(Game.Instance.knifeImage, Game.Instance.knifePanel);
        KnivesLeft = numberOfKnives;

        kniveDrawer.SetKnifes(KnivesLeft);
        Debug.Log(KnivesLeft);
    }

    void DecreaseKnife()
    {
        KnivesLeft--;
        kniveDrawer.SetKnifes(KnivesLeft);
    }

    ~KnifeManager()
    {
        EventManager.StopListening(this, "KnifeShot", () => KnivesLeft--);
    }
    

    public void SelectKnife(int id , AudioSource au ,AudioClip clip , GameObject kniveSelectionPanel)
    {
        au.PlayOneShot (clip);
        CurrentType = id;
        kniveSelectionPanel.SetActive (false);
    }
    
    public void SetType(int type)
    {
        CurrentType = type;
    }

    

}
