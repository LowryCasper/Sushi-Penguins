using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant : MonoBehaviour
{
    public float multiplier;

    public float duration;

    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PickUp());
        }
    }

    IEnumerator PickUp()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        player.transform.localScale *= multiplier;
        yield return new WaitForSeconds(duration);
        player.transform.localScale /= multiplier;
        Destroy(gameObject);

    }

}
