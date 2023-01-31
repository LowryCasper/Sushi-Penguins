using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public int LevelsToUnlock = 1;
    public bool gameWin;
     public int currentLevelPlayIndex;
   
    private Coroutine saveDataCoroutine;

    private void Awake()
    {

      
    }


    void Start()
    {
       //Load saved index of levelstounlock at the start of each stage
        LevelsToUnlock = PlayerPrefs.GetInt("NextStage", LevelsToUnlock);

        currentLevelPlayIndex = PlayerPrefs.GetInt("LevelSelected",currentLevelPlayIndex);

    }

    private void OnEnable()
    {
        GameManager.OnGameWIn += UnlockedNewLevel;
        //GameManager.OnGameWIn += WinLevel;
    }
    private void OnDisable()
    {
        GameManager.OnGameWIn -= UnlockedNewLevel;
    }

  

    public void UnlockedNewLevel()
    {
        if (!gameWin)
        {
            NextStage();
        }
            
           gameWin = true;
    }

    public void NextStage()
    {
        if(!SaveManager.instance.saveData.completedStages[currentLevelPlayIndex])
        {
            LevelsToUnlock++;
            saveDataCoroutine = StartCoroutine(SaveAfterDelay());
            PlayerPrefs.SetInt("NextStage", LevelsToUnlock);
            Debug.Log("Saved Next Stage");
            
        }
        else
        {
            if (saveDataCoroutine != null)
                StopCoroutine(saveDataCoroutine);
        }

        IEnumerator SaveAfterDelay()
        {
            yield return new WaitForSeconds(0.2f);
            SaveManager.instance.CompleteStage(currentLevelPlayIndex);
        }
      
    }






    

    
}
