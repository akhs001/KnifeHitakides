using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Pair
{
    public string ID;
    public AudioClip Clip;
}

public class SoundManager : Singleton<SoundManager>
{

    public List<Pair> pairs;
    AudioSource au;

    private void Start()
    {
        au  = GetComponent<AudioSource>();  
    }

    public void PlaySound(string ID )
    {
        au.PlayOneShot( pairs.Find( pair => pair.ID == ID ).Clip );
    }

    public void PlaySound(string ID , AudioSource _au)
    {
        _au.PlayOneShot(pairs.Find(pair => pair.ID == ID).Clip);
    }
}
