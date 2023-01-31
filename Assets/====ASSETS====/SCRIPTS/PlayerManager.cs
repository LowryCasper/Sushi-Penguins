using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] playerPrefab;
    public int currentPlayer;
    public PlayerIndexSO selectedPlayerindex;

    private GameObject SpawnedPlayer;
    

    private void Awake()
    {

        currentPlayer = PlayerPrefs.GetInt("selectedPlayer", currentPlayer);
        //currentPlayer = selectedPlayerindex.indexValue;
        SpawnedPlayer =Instantiate(playerPrefab[currentPlayer], transform.position, Quaternion.identity);

    }

    private void Update()
    {
      
           
    }

   // public void DestroyPlayer()
   // {
       // Destroy(SpawnedPlayer);

       // Instantiate(playerPrefab[currentPlayer], transform.position, Quaternion.identity);
   // }

  //  public void SpawningNewPlayer()
   // {
       // Instantiate(playerPrefab[currentPlayer], transform.position, Quaternion.identity);
   // }
}

