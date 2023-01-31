using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
   //private SushiController sushiController;

    public int duration;
    public GameObject[] sushi;

    private void Awake()
    {
        

    }

    private void Start()
    {
        sushi = GameObject.FindGameObjectsWithTag("Sushi");
            
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

        if(sushi !=null)
        foreach(var sushi in sushi)
        {
            sushi.GetComponent<SushiController>().magnetIsActive = true;
        }
            


        yield return new WaitForSeconds(duration);
        
        yield return new WaitForSeconds(1f);
        // sushiController.magnetIsActive = false;
        Destroy(gameObject);

    }
}
