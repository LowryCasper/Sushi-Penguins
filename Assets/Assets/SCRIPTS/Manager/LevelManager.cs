using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int targetWin;
    public int nextLevel;
    public int currentLevelPlayIndex;

    public LevelCompleteSO[] levelCompleteSO;




    private void Awake()
    {
        

    }

   
    void Start()
    {
        //set the index of new level being instantiated. this index comes from each button stage selected
        currentLevelPlayIndex = PlayerPrefs.GetInt("LevelSelected", currentLevelPlayIndex);

        //the data comes from levelscompleteSO. each level has different value from each SO
        instance = this;
        targetWin = levelCompleteSO[currentLevelPlayIndex].sushiToWin;

        //check if the scene is level gameplay only, then instantiate the level prefab
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level Gameplay")
        {
            Instantiate(levelCompleteSO[currentLevelPlayIndex].LevelPrefab, transform.position, Quaternion.identity);
        }

    }

    // onclick event to set the index of level selected in each button clicked at stage selection
    public void SetCurrentLevelIndex(int level)
    {

        PlayerPrefs.SetInt("LevelSelected", level);
    }




}