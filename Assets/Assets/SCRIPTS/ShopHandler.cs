using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : MonoBehaviour
{
    public GameObject playerSelectUI;

    public GameObject playButtonUI;

    public GameObject resetButtonUI;

    public GameObject shopButtonUI;
    


    // Start is called before the first frame update
    void Start()
    {
        playerSelectUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivatePlayerSelectUI()
    {
            shopButtonUI.SetActive(false);
            playerSelectUI.SetActive(true);
            playButtonUI.SetActive(false);
            resetButtonUI.SetActive(false);
     }

    public void ClosePlayerSelectUI()
    {
        shopButtonUI.SetActive(true);
        playerSelectUI.SetActive(false);
        playButtonUI.SetActive(true);
        resetButtonUI.SetActive(true);
    }

   
}
