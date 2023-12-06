using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//11/21

public class PlayerLook : MonoBehaviour
{
    [SerializeField] float minViewDistance = 25f;

    public float mouseSensitivity = 100f;

    [SerializeField] Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //get input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        //Clamp hpw far player can look
        xRotation = Mathf.Clamp(xRotation, -90f, minViewDistance);

        //rotate the camera and player
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
