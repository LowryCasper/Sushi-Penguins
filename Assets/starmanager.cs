using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starmanager : MonoBehaviour
{
    private int numberOfLevels;
    public List<int> starCollectedList;

    private void Start()
    {
        numberOfLevels = LevelManager._instance.currentLevelPlayIndex;
        starCollectedList = new List<int>();
        for (int level = 0; level <= numberOfLevels; level++)
        {
            string key = "StarCollected" + level;
            int starCollected = PlayerPrefs.GetInt(key, 0);
            starCollectedList.Add(starCollected);
        }
    }

    private void Update()
    {
       
    }
}
