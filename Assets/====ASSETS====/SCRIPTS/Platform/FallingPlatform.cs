using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
   
        public float fallDelay = 4f;
        private Rigidbody2D rb2d;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                StartCoroutine(Fall());
            }
        }

        IEnumerator Fall()
        {
            yield return new WaitForSeconds(fallDelay);
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.gravityScale = 1;
            //GetComponent<Collider2D>().isTrigger = false;
            yield return 0;

        Destroy(gameObject,1);
        }
    }
