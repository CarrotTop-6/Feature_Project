using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

//Jack Bradford
//Controls Titan spawn
//11/7/2023

public class TitanController1 : MonoBehaviour
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

        transform.position = new Vector3(transform.position.x, transform.position.y + 300, transform.position.z);
    }


    //On spawn fall until ground
    private void Update()
    {
        inbound();
    }


    //fall until the titan hits the ground
    private void inbound()
    {
        if (groundContact == false)
        {
            rb.velocity = new Vector3(0, fallSpeed, 0);
        }
    }

    //Collisions
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
