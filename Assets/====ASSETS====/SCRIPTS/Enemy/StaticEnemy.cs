using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    public int force;

    public GameObject player;
    public GameObject gameOverPanel;
    public Rigidbody2D rb;
    public PlayerController playerController;

    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
      
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
        rb = player.GetComponent<Rigidbody2D>();

      
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

