using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Controls Titan spawning, movement, and abilities
//11/7/2023

public class TitanController : MonoBehaviour
{
    //Variables
    private float fallSpeed;
    private bool groundContact = false;

    //On spawn fall until ground

    //When player inside
    //Move
    //Dash??
    //Abilities
    //Core Ability

    private void inbound()
    {
        while (groundContact == false)
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enviroment"))
        {
            Debug.Log("Floor");
        }
    }
}
