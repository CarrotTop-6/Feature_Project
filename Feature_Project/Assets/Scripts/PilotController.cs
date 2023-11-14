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
    }

    private void titanFall()
    {
        Instantiate(titan, new Vector3(transform.position.x + 5, transform.position.y + 50, transform.position.z), Quaternion.identity);
    }
}
