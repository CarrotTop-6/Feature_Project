using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitanMove : MonoBehaviour
{
    public Rigidbody rb;
    private float moveSpeed = 10.0f;
    Vector2 moveInput;

    public bool inTitan = false;

    // Update is called once per frame
    void Update()
    {
        //Checks to make sure player is not in titan
        inTitan = GameObject.Find("Player_Pilot").GetComponent<PilotController>().insideTitan;
        if (inTitan == false)
        {
            Run();
        }
    }

    //get move value
    private void Run()
    {
        Vector3 playerVelocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);
        rb.velocity = transform.TransformDirection(playerVelocity);
    }
}
