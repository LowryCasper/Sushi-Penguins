using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalator : MonoBehaviour
{
    public float escalatorSpeed;
    public GameObject player;
    public Rigidbody2D rb;
    public PlayerController playerController;
    public bool isOnEscalator = false;

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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Debug.Log("Player is on the platform");
          //  rb.velocity = new Vector2(rb.velocity.y, escalatorSpeed * Time.deltaTime);
       // player.transform.Translate(Vector2.right * Time.deltaTime * escalatorSpeed);

    }
    void FixedUpdate()
    {
        if(isOnEscalator)
        player.transform.Translate(Vector2.right * Time.deltaTime * escalatorSpeed);
        // Move player horizontally to the right with time del ata time
        //  transform.Translate(new Vector2(escalatorSpeed * Time.deltaTime, 0f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isOnEscalator = true;
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isOnEscalator = false;
    }
  

    public void autoMove()
    {
        player.transform.Translate(Vector2.right * Time.deltaTime * escalatorSpeed);
    }
}

