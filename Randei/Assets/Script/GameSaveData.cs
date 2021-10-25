using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSaveData
{
    public int score = 0;
    
    public int gold = 0;
    public int health = 0;
    public int skill = 0;
    public float rate = 1.0f;
    public int[] ranking = new int[5];
    //public int[] ranking = { 1, 3, 2345, 4, 8 };
}
