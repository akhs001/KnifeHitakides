using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    List<ISaveLoad> saveAndLoad;

    private void Start()
    {
        saveAndLoad = new List<ISaveLoad>();
        saveAndLoad = FindObjectsOfType<MonoBehaviour>().OfType<ISaveLoad>().ToList();
    }


    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            saveAndLoad.ForEach(i => i?.Save());
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        saveAndLoad.ForEach(i => i?.Save());
    }

    private void OnApplicationQuit()
    {
       saveAndLoad.ForEach(i=> i?.Save()); 
    }
}
