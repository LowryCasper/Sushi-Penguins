using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUp : MonoBehaviour
{

    public int addTime;
    public GameObject Timer;
    public Timer timer;
    private void Start()
    {
        Timer = GameObject.Find("Timer");
        timer = Timer.GetComponent<Timer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timer.timeRemaining += addTime;
            Debug.Log("Add Extra Time");
            Destroy(gameObject);
        }
      
    }
}
