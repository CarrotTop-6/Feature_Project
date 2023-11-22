using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//Jack Bradford
//Controls the pilots movement and can deploy a titan
//11/7/2023



//CinemaChine

public class PilotController : MonoBehaviour
{
    //Variables
    public GameObject titan;
    public GameObject dropLocation;

    public PlayerInputActions pilotControls;
    private InputAction move;
    private InputAction fire;
    private InputAction titanSpawn;

    Vector3 moveDirection = Vector3.zero;
    public Rigidbody rb;
    private float moveSpeed = 5.0f;

    [SerializeField]
    private bool titanActive = false;

    public TMP_Text embarkText;
    private float embarkDist = 7f;

    //public Transform Pilot;


    //Update
    //Movement
    //Jump
    //Look

    private void Awake()
    {
        pilotControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = pilotControls.Player.Move;
        move.Enable();

        fire = pilotControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

        titanSpawn = pilotControls.Player.Titan;
        titanSpawn.Enable();
        titanSpawn.performed += titanFall;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        titanSpawn.Disable();
    }

    //Spawn Titan (raycast / position in front)
    //Detect range to titan (distance / box collider)
    private void Update()
    {
        /*
        moveDirection = move.ReadValue<Vector2>();
        if (Input.GetKeyDown(KeyCode.E))
        {
            titanFall();
        }
        */

        if(titanActive)
        {
            if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.FindGameObjectWithTag("Titan").transform.position) < embarkDist) 
            {
                Debug.Log("X to Embark");
                embarkText.text = "X to Embark";
            }
            else
            {
                embarkText.text = "";
            }
        }
        
    }



    private void FixedUpdate()
    {
        //rb.velocity = 
        //transform.position = Vector3.forward * moveDirection.x * moveSpeed;
        //new Vector3(moveDirection.x * moveSpeed, moveDirection.z * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }

    private void titanFall(InputAction.CallbackContext context)
    {
        if(titanActive == false)
        {
            titanActive = true;
            //transform.position.x + 10, transform.position.y + 300, transform.position.z  inside Vector3
            Instantiate(titan, new Vector3(0, 300, 0), Quaternion.Euler(new Vector3(0, -90, 0))); 
            Instantiate(dropLocation, new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
    }
}
