using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Controls Titan spawning, movement, and abilities
//11/7/2023

public class TitanController : MonoBehaviour
{
    //Variables
    private float fallSpeed = -80;
    private bool groundContact = false;
    public Rigidbody rb;


    private void Awake()
    {
        /*
        transform.LookAt(Pilot.transform.position);
        //transform.Rotate(0, 0, 0);
        */

        /*
        GameObject Pilot = GameObject.Find("Player_Pilot");
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position - Pilot.transform.position), 100f);
        */

        /*
        Vector3 direction = Pilot.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        */
    }


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

        if(collision.gameObject.CompareTag("LandingPad"))
        {
            Destroy(collision.gameObject);
        }
    }
}
