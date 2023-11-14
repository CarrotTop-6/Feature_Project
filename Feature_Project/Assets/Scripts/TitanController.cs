using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Controls Titan spawning, movement, and abilities
//11/7/2023

public class TitanController : MonoBehaviour
{
    //Variables
    private float fallSpeed = -30;
    private bool groundContact = false;
    public Rigidbody rb;

    //On spawn fall until ground
    private void Update()
    {
        inbound();
    }
    //When player inside
    //Move
    //Dash??
    //Abilities
    //Core Ability

    private void inbound()
    {
        if (groundContact == false)
        {
            rb.velocity = new Vector3(0, fallSpeed, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enviroment"))
        {
            Debug.Log("Floor");
            groundContact = true;
        }
    }
}
