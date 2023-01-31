using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // the speed at which the bullet will travel
    public Rigidbody2D bulletrb;
    public GameObject player;
    public GameObject gameOverPanel;
    public Rigidbody2D rb;
    public PlayerController playerController;
    public int force;

    private void Start()
    {
        bulletrb = GetComponent<Rigidbody2D>();

        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
        rb = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
       // rb.velocity = new Vector2(rb.velocity.x, speed * Time.deltaTime); ;
        transform.position += transform.right * speed * Time.deltaTime;
        Invoke("DestroyBullet", 5);
    }


    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
       // StartCoroutine(GameoverDelay());
    }


   // IEnumerator GameoverDelay()
    //{
       // yield return new WaitForSeconds(1f);
       // gameOverPanel.SetActive(true);
       // Time.timeScale = 0;
   // }
}




