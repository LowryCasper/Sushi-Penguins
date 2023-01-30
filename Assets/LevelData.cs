using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelData : MonoBehaviour
{
    public int levelNumber;
    public float currentPercentage;
    public int starCollected;


    private void Awake()
    {
        starCollected = PlayerPrefs.GetInt("StarCollected" + levelNumber, starCollected);
    }
    // Start is called before the first frame update
    void Start()
    {
        levelNumber = LevelManager._instance.currentLevelPlayIndex;
       

        }

    // Update is called once per frame
    void Update()
    {
       
     
        if (GameManager.instance.gameWin)
        {
            currentPercentage = GameManager.instance.currentScorePercentage;
            starCollected = GameManager.instance.starCollected;
            SaveStar();
        }
                
      
    }

    
    
    public void SaveStar()
    {
        PlayerPrefs.SetInt("StarCollected" + levelNumber, starCollected);
        PlayerPrefs.SetFloat("CurrentPercentage" + levelNumber, currentPercentage);

        Debug.Log("SaveData");
    }
}
