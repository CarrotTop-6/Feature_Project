using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Controls the auncher weapon
//11/28/23

public class LaunchProjectile : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectile;
    public float launchVelocity = 10f;

    private void Update()
    {
        if(Input.GetKeyDown("k"))
        {
            //shoot projectile forward, and gravity will pull it down
            var _projectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
            _projectile.GetComponent<Rigidbody>().velocity = launchPoint.forward * launchVelocity;
        }
    }
}
