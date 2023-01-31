using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WinCondition : MonoBehaviour
{
    public int targetWin;

    public int nextLevel;

    public int currentLevelIndex;

    public LevelManager levelManager;

    

    

   // public LevelCompleteSO[] levelCompleteSO;

   

   


    private void Awake()
    {
       // currentLevelIndex = levelManager.currentLevelPlayIndex;

       // targetWin = levelCompleteSO[currentLevelIndex].sushiToWin;

       // nextLevel = levelCompleteSO[currentLevelIndex].nextLeveltoUnlocked;
        
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        //if (!levelCompleteSO[currentLevelIndex].isCompleted)
        {
            GameManager.OnGameWIn += SaveLevelCompleted;
            PlayerPrefs.SetInt("LevelReached", nextLevel);
            Debug.Log("Level is complete");
        }

       
    }
    private void OnDisable()
    {
       
          //  GameManager.OnGameWIn -= SaveLevelCompleted;
           
    }


    public void SaveLevelCompleted()
    {

        Debug.Log("saved reachedlevel");

       // levelCompleteSO[currentLevelIndex].isCompleted = true;
      //  levelManager.levelCompleteSO[currentLevelIndex].isCompleted = true;
        

    }

   
}
