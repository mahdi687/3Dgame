using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool canShoot; 
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 1;

    void Update()
    {
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Invoke("shoot", 0.3f);
            }
        }
    }

    public void shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }
    

}
