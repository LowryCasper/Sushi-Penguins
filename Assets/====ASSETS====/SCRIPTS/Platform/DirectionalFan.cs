using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalFan : MonoBehaviour
{
    public GameObject player;

    public Rigidbody2D rb;
    public PlayerController playerController;
    float xVelocity = 5f;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
        rb = player.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            rb.velocity = new Vector2(xVelocity, rb.velocity.y);
    
        
    }
}
