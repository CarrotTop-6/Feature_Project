using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Controls the pilots movement and can deploy a titan
//11/7/2023



//CinemaChine

public class PilotController : MonoBehaviour
{
    //Variables
    public GameObject titan;
    public GameObject dropLocation;

    public Rigidbody rb;

    [SerializeField]
    private bool titanActive = false;

    //Update
    //Movement
    //Jump
    //Look

    //Spawn Titan (raycast / position in front)
    //Detect range to titan (distance / box collider)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            titanFall();
        }

        if(titanActive)
        {
            if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.FindGameObjectWithTag("Titan").transform.position) < 5) 
            {
                Debug.Log("X to Embark");
            } 
        }
    }

    private void titanFall()
    {
        titanActive = true;
        Instantiate(titan, new Vector3(transform.position.x + 10, transform.position.y + 300, transform.position.z), Quaternion.identity);
        Instantiate(dropLocation, new Vector3(transform.position.x + 10, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
    }
}
