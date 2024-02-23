using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Standard bullet
//11/26/23

public class Bullet : MonoBehaviour
{
    protected void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
