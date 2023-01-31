using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelComplete", menuName = "ScriptableObjects/Level")]
public class LevelCompleteSO : ScriptableObject
{

    public string levelName;
    public int saveLevelIndex;
    public GameObject LevelPrefab;
    public int sushiToWin;
    public int starCollected;
    public int currentSushi;
    
    

}
