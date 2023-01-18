using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour

{
    public Transform player;



    private void Update()
    {
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
           collision.transform.SetParent(player);
    }
  
   
}
