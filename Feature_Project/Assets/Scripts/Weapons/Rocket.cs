using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    public GameObject explosion;
    

    private void OnCollisionEnter(Collision collision)
    {
        var expRadius =Instantiate(explosion, this.transform.position, this.transform.rotation);
        base.OnCollisionEnter(collision);
    }
}
