using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitanMove : MonoBehaviour
{
    public Rigidbody rb;
    private float moveSpeed = 10.0f;
    Vector2 moveInput;

    public bool inTitan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inTitan = GameObject.Find("Player_Pilot").GetComponent<PilotController>().insideTitan;
        Debug.Log("1");
        if (inTitan == true)
        {
            Debug.Log("2");
            Run();
        }
    }

    private void Run()
    {
        Vector3 playerVelocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);
        rb.velocity = transform.TransformDirection(playerVelocity);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
