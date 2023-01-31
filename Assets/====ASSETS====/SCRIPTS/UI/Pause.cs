using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            pause.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            pause.SetActive(true);
        }
    }

    public void UnPausedGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pause.SetActive(false);
    }
}
