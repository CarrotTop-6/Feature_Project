using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Jack Bradford
//Controls titan movement
//11/22/23

public class TitanMove : MonoBehaviour
{
    public Rigidbody rb;
    private float moveSpeed = 10.0f;
    Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //Check to see if pilot is ininside, then move
    void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        inTitan = GameObject.Find("Player_Pilot").GetComponent<PilotController>().insideTitan;
=======
        inTitan = GameObject.Find("Player_Pilot").GetComponent<PilotController>().insideTitan;   //Tried to make PilotController a static variable, but it would not let me create an instance of the boolean
>>>>>>> parent of 776b46b (Revert "Final version finished")
        if (inTitan == true)
=======

        if (PilotController.Instance.insideTitan == true)
>>>>>>> parent of ee81c9e (Titan camera and controls switch, 4 working guns)
        {
            Run();
        }
    }

    //Get move value
    private void Run()
    {
        Vector3 playerVelocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);
        rb.velocity = transform.TransformDirection(playerVelocity);
    }

    //Change position to move value
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
