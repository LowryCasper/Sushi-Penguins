using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public GameObject bulletPrefab; // Drag and drop the ball prefab in the Inspector
    public float shootingInterval = 5.0f; // Interval at which the ball will be shot
    public float shootingForce = 500.0f; // Force with which the ball will be shot
    public Transform shootingPoint; // Transform component of the shooting point (where the ball will be instantiated)

    private float timeSinceLastShot = 0.0f; // Time elapsed since the last shot

    void Update()
    {
        // Update the time elapsed since the last shot
        timeSinceLastShot += Time.deltaTime;

        // If the shooting interval has passed
        if (timeSinceLastShot >= shootingInterval)
        {
            // Reset the time elapsed since the last shot
            timeSinceLastShot = 0.0f;

            // Instantiate the ball at the shooting point
            Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);

            // Get the Rigidbody component of the ball
            Rigidbody2D ballRigidbody = bulletPrefab.GetComponent<Rigidbody2D>();

            // Add a force to the ball in the direction of the shooting point's forward vector
            ballRigidbody.AddForce(shootingPoint.forward * shootingForce);
        }

    }
}

