using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> :MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = (T)FindObjectOfType<T>();
                if(_instance == null)
                {
                    var singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).Name.ToString()+ " Singleton";

                     DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }



}
