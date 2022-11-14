using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager :Singleton<LevelManager> ,ISaveLoad
{
   public  List<LevelSO> allLevels;
    private int currentLevel=0;

    public int CurrentLevel => currentLevel;

    public void Load()
    {

    }

    public void Save()
    {
 
    }

    void Start()
    {
        
    }

}
