using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMechanic : MonoBehaviour
{

    public int jumpPower;

    public GameObject player;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

    }

    
  
}
