using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Level" , fileName ="new Level")]
public class LevelSO : ScriptableObject
{
    public new string name;
    public GameObject sprite;
    public int direction;
    public int speed;
}
