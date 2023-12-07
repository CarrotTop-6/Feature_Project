using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Jack Bradford
//Controls player movement
//11/20/23

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    private float moveSpeed = 10.0f;
    Vector2 moveInput;

    public bool inTitan = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    
    //set movement
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
