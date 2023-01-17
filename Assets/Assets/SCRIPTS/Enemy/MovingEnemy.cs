using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public GameObject[] wayPoints;
    public int currentWaypointIndex;

    public float speed;
    public int force;

    public GameObject player;
    public GameObject gameOverPanel;
    public Rigidbody2D rb;
    public PlayerController playerController;
    // Update is called once per frame

    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
        rb = player.GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (Vector2.Distance(wayPoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
        StartCoroutine(GameoverDelay());
    }


    IEnumerator GameoverDelay()
    {
        yield return new WaitForSeconds(1f);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
