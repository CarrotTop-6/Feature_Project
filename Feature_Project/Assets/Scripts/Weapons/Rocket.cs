using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

//Jack Bradford
//Controls the rockets
//12/1/23

public class Rocket : Bullet
{
    public GameObject explosion;
    
    //spawn an explosion where rocket hits
    private void OnCollisionEnter(Collision collision)
    {
        var expRadius =Instantiate(explosion, this.transform.position, this.transform.rotation);
        base.OnCollisionEnter(collision);
    }
}
