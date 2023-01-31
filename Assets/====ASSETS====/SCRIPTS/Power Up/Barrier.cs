using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            ActivateBarrier();
    }

    public void ActivateBarrier()
    {
        GameObject Barrier = player.transform.Find("Barrier").gameObject;

        Barrier.SetActive(true);
        StartCoroutine(BarrierDuration());
        
    }

    IEnumerator BarrierDuration()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(1f);
        GameObject Barrier = player.transform.Find("Barrier").gameObject;

        Barrier.SetActive(false);
        // sushiController.magnetIsActive = false;
        Destroy(gameObject);
        
    }
}