using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public GameObject sushiPrefab;
    public int maxCoins = 5;
    public float spawnRadius = 0.5f;
    public bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            OpenBox();

    }

    void OpenBox()
    {
        isOpen = true;
        int coinsToInstantiate = Random.Range(1, maxCoins);
        for (int i = 0; i < coinsToInstantiate; i++)
        {
            Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(sushiPrefab, spawnPos, Quaternion.identity);
        }


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
