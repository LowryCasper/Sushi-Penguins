using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static event Action OnGameWIn;

    public GameObject timer;
  

    public LevelManager levelManager;

    public int currentLevelIndex;

   // public int leveltoUnlock;
   // public int UnlockedLevel;

    public int score;

    public bool gameWin = false;

    public int targetScore;

    public float currentScorePercentage;
    public int starCollected;

    public GameObject winStageUI;
    public GameObject gameOverUI;
    private Coroutine winningStageCoroutine;



    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;


        instance = this;




    }
        void Start()
    {
       instance = this;

        currentLevelIndex = levelManager.currentLevelPlayIndex;
        targetScore = levelManager.levelCompleteSO[currentLevelIndex].sushiToWin;

     
    }

    // Update is called once per frame
    void Update()
    {
        CalculatePercentage();
        LevelCompleted();
        UpdateStarCollected();

    }

    public void WinStage()
    {
       
        
            
             Invoke("ActivateWinUI", 0.3f);

            winningStageCoroutine =StartCoroutine(WinningStage());
            if (winningStageCoroutine != null)
                StopCoroutine(winningStageCoroutine);

        

      
         gameWin = false;
      


    }

    IEnumerator WinningStage()
    {
        //Stop all movement after seconds of winning the stage
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }

    public void LevelCompleted()
    {
        //Check if score is equal the targetscore and the game isnt win yet,then invoke ongamewin action
        
        if (score >= targetScore && !gameWin)
        {
            WinStage();
            OnGameWIn?.Invoke();
           
            gameWin = true;                      
        }
            
    }

    private void ActivateWinUI()
    {
        winStageUI.SetActive(true);
    }

    public void CalculatePercentage()
    {
        currentScorePercentage = (int)((float)score / targetScore * 100);
    }

    public void UpdateStarCollected()
    {
        switch (currentScorePercentage)
        {
            case float n when (n < 30):
                starCollected = 1;
                break;
            case float n when (n >= 30 && n <= 66):
                starCollected = 2;
                break;
            default:
                starCollected = 3;
                break;
        }
    }

}
