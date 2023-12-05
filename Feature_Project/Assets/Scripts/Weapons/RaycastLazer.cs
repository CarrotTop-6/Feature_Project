using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Controls the laser weapon
//11/28/23

public class RaycastLazer : MonoBehaviour
{
    public Camera playerCamrea;
    public Transform lazerOrigin;
    public float lazerRange = 50f;
    public float fireRate = 1.0f;
    public float lazerDuration = 1f;

    LineRenderer lazerLine;
    float fireTimer;

    //find linerenderer
    private void Awake()
    {
        lazerLine = GetComponent<LineRenderer>();
    }

    //fire lazer at position camera is looking at
    private void Update()
    {
        fireTimer += Time.deltaTime;
        if(Input.GetKeyDown("l") && fireTimer > fireRate)
        {
            fireTimer = 0;
            lazerLine.SetPosition(0, lazerOrigin.position);
            Vector3 rayOrigin = playerCamrea.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            //check to see if raycast is out of range of laser
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
    }

    //enable line for set duration
    IEnumerator ShootLazer()
    {
        lazerLine.enabled = true;
        yield return new WaitForSeconds(lazerDuration);
        lazerLine.enabled = false;
    }
}
