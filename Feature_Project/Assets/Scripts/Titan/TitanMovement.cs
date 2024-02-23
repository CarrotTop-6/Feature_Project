using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitanMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to set the movement speed
    public bool inTitan = false;

    void Update()
    {
        inTitan = (GameObject.Find("Player_Pilot").GetComponent<PilotController>().insideTitan);
        if (inTitan)
        {
            MoveObjectForward();
        }

    }

    void MoveObjectForward()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }



    /*
     * 
    public Rigidbody rb;
    public float moveSpeed = 5.0f;

    public bool inTitan = false;

    //Vector2 moveInput;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Run();

        inTitan = (GameObject.Find("Player_Pilot").GetComponent<PilotController>().insideTitan);
        if(inTitan)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("forwards");
                MoveObjectForward();

                //transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
            }


            //moveDirection = titanControls.ReadValue<Vector3>();
        }
    }

    void MoveObjectForward()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        rb.AddForce(movement * moveSpeed);
    }


    /*
    private void Run()
    {
        Vector3 titanVelocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);
        rb.velocity = transform.TransformDirection(titanVelocity);
    }
    */

    /*
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log("OnMove");
    }
    







    private void FixedUpdate()
    {
        if(inTitan)
        {




            //transform.position += Vector3.forward * Time.deltaTime;
            //rb.velocity = transform.forward * moveDirection.x;
                //new Vector3(moveDirection.x * moveSpeed, moveDirection.y, moveDirection.z * moveSpeed);
            
        }
    }
    */
}
