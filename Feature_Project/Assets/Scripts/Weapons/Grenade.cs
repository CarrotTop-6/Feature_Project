using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Bullet
{
    public GameObject explosion;

    //spawn an explosion where rocket hits
    private void OnCollisionEnter(Collision collision)
    {
        var expRadius = Instantiate(explosion, this.transform.position, this.transform.rotation);
        base.OnCollisionEnter(collision);
    }
}
