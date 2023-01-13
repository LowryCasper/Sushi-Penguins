using System.Collections;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    public float destructionDelay = 3.0f; // Delay before destroying the ball

    void Start()
    {
        // Destroy the ball after the specified delay
        Destroy(gameObject, destructionDelay);
        Debug.Log("Bullet destroyed");
    }
}
