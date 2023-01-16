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

        LevelCompleted();


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



}
