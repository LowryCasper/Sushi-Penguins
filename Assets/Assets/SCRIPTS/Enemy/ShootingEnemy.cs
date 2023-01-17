using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject bulletPrefab; // drag and drop the bullet prefab to this variable in the inspector
    public float fireRate = 1f; // the interval at which the enemy will fire bullets

    private float nextFireTime;

    void Start()
    {
        nextFireTime = Time.time;
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
        //bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bullet.GetComponent<Bullet>().speed;
    }
}
