using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Control standard gun
//11/26/23

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("o"))
        {
            //shoot bullet forward
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
