using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    public int[] starsCollected;
    public GameObject[] star;
   
    public int starCollected;
    
    
    // Start is called before the first frame update
    void Start()
    {
      
        foreach (GameObject Star in star)
        {
            Star.SetActive(false);
        }

    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
