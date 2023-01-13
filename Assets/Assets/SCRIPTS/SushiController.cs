using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiController : MonoBehaviour
{
    [Range(.1f, 5)]
    public float radius;
    public bool magnetIsActive = false;

    public int speed;

    public GameObject player;

    public LayerMask targetPlayer;

    public Color gizmoColor = Color.green;
    public bool showGizmos = true;

    public bool playerDetected;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        //OnDrawGizmos();

        magnetIsActive = false;
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        GameManager.instance.score++;

    }
    private void Update()
    {
        var collider = (Physics2D.OverlapCircle(transform.position, radius, targetPlayer));

        playerDetected = collider != null;
        if (playerDetected && magnetIsActive)
        {
            MagnetSushi();
        }
        
    }



    public void MagnetSushi()
    {
       
       transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);

    }

    public void OnDrawGizmos()
    {
        if(showGizmos)
        Gizmos.DrawSphere(transform.position, radius);
    }
}
