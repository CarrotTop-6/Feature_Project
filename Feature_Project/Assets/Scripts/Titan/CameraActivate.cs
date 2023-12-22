using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Activate the camera when player enters
//11/21/23

public class CameraActivate : MonoBehaviour
{
    public GameObject titanCameraVC;
    private bool inTitan;

    // Update is called once per frame
    void Update()
    {
        inTitan = GameObject.Find("Player_Pilot").GetComponent<PilotController>().insideTitan;
        if (inTitan == true)
        {
            titanCameraVC.SetActive(true);
        }
    }
}
