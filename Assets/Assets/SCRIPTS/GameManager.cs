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
    public float scorePercentage;
    public int StarCollected;

    public GameObject winStageUI;
    public GameObject gameOverUI;
    private Coroutine winningStageCoroutine;



    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;


        instance = this;




    }
      public  void Start()
    {


        currentLevelIndex = LevelManager.instance.currentLevelPlayIndex;
        targetScore = LevelManager.instance.targetWin;
        

    }

    // Update is called once per frame
   public void Update()
    {
        CalculateScorePercentage();
        LevelCompleted();
        GetStarRequirement();

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
     
    public void CalculateScorePercentage()
    {
        scorePercentage = (int)((float)score/ targetScore * 100);
    }

    public void GetStarRequirement()
    {
        
          
            switch (scorePercentage)
            {
                case var p when p < 30:
                StarCollected = 1;
                    break;
                case var p when p >= 30 && p <= 66:
                StarCollected = 2;
                    break;
                default:
                StarCollected = 3;
                    break;
            }
           
        

    }
}
