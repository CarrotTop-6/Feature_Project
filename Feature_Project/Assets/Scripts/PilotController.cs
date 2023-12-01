using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Cinemachine;

//Jack Bradford
//Controls the pilots movement and can deploy a titan
//11/7/2023



//CinemaChine

public class PilotController : MonoBehaviour
{
    public CinemachineVirtualCamera vcCamera;
    public CinemachineVirtualCamera titanCamera;

    [Header("Titan")]
    public GameObject titan;
    public Transform titan_transform;
    public GameObject dropLocation;
    public bool insideTitan = false;
    public GameObject pilot;
    public float distanceFromPilot = 2;

    [Header("Embark")]
    public bool insideEmbark = false;
    public TMP_Text embarkText;
    private float embarkDist = 7f;

    [Header("Input Actions")]
    public PlayerInputActions pilotControls;
    private InputAction move;
    private InputAction fire;
    private InputAction enterTitan;
    private InputAction titanSpawn;

    [Header("Pilot Movement")]
    Vector3 moveDirection = Vector3.zero;
    public Rigidbody rb;
    private float moveSpeed = 5.0f;

    [SerializeField]
    private bool titanActive = false;


    [Header("Bullet")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    


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
        titanSpawn.performed += TitanFall;

        enterTitan = pilotControls.Player.Embark;
        enterTitan.Enable();
        enterTitan.performed += Embark;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        titanSpawn.Disable();
        enterTitan.Disable();
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
                insideEmbark = true;
                embarkText.text = "X to Embark";
            }
            else
            {
                insideEmbark = false;
                embarkText.text = "";
            }
        }
        
        if(insideTitan == true)
        {
            //turns pilot off, potentially
            //pilot.SetActive(false);
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

        /*
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        */
    }

    private void TitanFall(InputAction.CallbackContext context)
    {
        if(titanActive == false)
        {
            titanActive = true;
            //transform.position.x + 10, transform.position.y + 300, transform.position.z  inside Vector3
            //Instantiate(titan, new Vector3(0, 300, 0), Quaternion.Euler(new Vector3(0, -90, 0)));
            //Instantiate(dropLocation, new Vector3(0, 0.5f, 0), Quaternion.identity);

            Vector3 pilotPos = pilot.transform.position;
            Vector3 pilotDirection = pilot.transform.forward;
            Quaternion pilotRotation = pilot.transform.rotation;
            float spawnDistance = 15;

            Vector3 spawnPos = pilotPos + pilotDirection * spawnDistance;

            Instantiate(titan, spawnPos , Quaternion.identity);

            Instantiate(dropLocation, spawnPos, Quaternion.identity);
        }
    }

    private void Embark(InputAction.CallbackContext context)
    {
        if(insideEmbark == true)
        {
            Debug.Log("In range to get in titan");
            insideTitan = true;
            //vcCamera.Follow = titan_transform.transform;
            
        }
        else
        {
            Debug.Log("not in range");
        }
    }

    private void SwitchToCamera (CinemachineVirtualCamera targetCamera)
    {

    }
}
