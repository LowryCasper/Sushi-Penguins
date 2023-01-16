using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining; // time in seconds
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;
    public GameObject winStageUI;
    public bool WinStage;

    private void Start()
    {

    }

    void Update()
    {
      
        timeRemaining -= Time.deltaTime;
        int minutes = (int)timeRemaining / 60;
        int seconds = (int)timeRemaining % 60;
        timerText.text = " " + string.Format("{0:00}:{1:00}", minutes, seconds);


        if (timeRemaining <= 0 && winStageUI.activeInHierarchy == false)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0; // pause the game
        }
        else
        {
            if (winStageUI.activeInHierarchy)
                
                Invoke("PauseTimer", 2f);

        }


    }
    private void PauseTimer()
    {
        Time.timeScale = 0;


    }
}