using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastLazer : MonoBehaviour
{
    public Camera playerCamrea;
    public Transform lazerOrigin;
    public float lazerRange = 50f;
    public float fireRate = 1.0f;
    public float lazerDuration = 1f;

    public PlayerInputActions titanControls;
    private InputAction ionBeam;

    LineRenderer lazerLine;
    float fireTimer;

    private void Awake()
    {
        lazerLine = GetComponent<LineRenderer>();
        titanControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        ionBeam = titanControls.Titan.IonBeam;
        ionBeam.Enable();
        ionBeam.performed += IonBeam;
    }

    private void Update()
    {
        /*
        fireTimer += Time.deltaTime;
        if(Input.GetKeyDown("l") && fireTimer > fireRate)
        {
            fireTimer = 0;
            lazerLine.SetPosition(0, lazerOrigin.position);
            Vector3 rayOrigin = playerCamrea.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(rayOrigin, playerCamrea.transform.forward, out hit, lazerRange))
            {
                lazerLine.SetPosition(1, hit.point);
                //Destroy(hit.transform.gameObject);
            }
            else
            {
                lazerLine.SetPosition(1, rayOrigin + (playerCamrea.transform.forward * lazerRange));
            }
            StartCoroutine(ShootLazer());
        }
        */
    }

    //Swtiched to new Input System
    private void IonBeam(InputAction.CallbackContext context)
    {
        Debug.Log("Laser");
        fireTimer += Time.deltaTime;
            fireTimer = 0;
            lazerLine.SetPosition(0, lazerOrigin.position);
            Vector3 rayOrigin = playerCamrea.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            //check to see if raycast is out of range of laser
            if (Physics.Raycast(rayOrigin, playerCamrea.transform.forward, out hit, lazerRange))
            {
                Debug.Log("Hit");
                lazerLine.SetPosition(1, hit.point);
                //Destroy(hit.transform.gameObject);
            }
            else
            {
                lazerLine.SetPosition(1, rayOrigin + (playerCamrea.transform.forward * lazerRange));
            }
            StartCoroutine(ShootLazer());
    }

    IEnumerator ShootLazer()
    {
        lazerLine.enabled = true;
        yield return new WaitForSeconds(lazerDuration);
        lazerLine.enabled = false;
    }
}
