using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerCore : MonoBehaviour
{
    public Camera playerCamrea;
    public Transform lazerOrigin;
    public float lazerRange = 60f;
    public float fireRate = 5.0f;
    public float lazerDuration = 0.4f;

    LineRenderer lazerLine;
    float fireTimer;

    public bool lazerEnabled = false;

    private void Awake()
    {
        lazerLine = GetComponent<LineRenderer>();
        fireTimer += 20.0f;
    }

    private void Update()
    {
        if(Input.GetKeyDown("i") && fireTimer > fireRate && lazerEnabled == false)
        {
            Debug.Log("laser");
            StartCoroutine(EnableLazer());
        }

        if (lazerEnabled == true)
        {

            //no workie



            Vector3 rayOrigin = new Vector3(lazerOrigin.position.x, lazerOrigin.position.y, lazerOrigin.position.z);
            Ray ray = new Ray(rayOrigin, playerCamrea.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, lazerRange))
            {
                lazerLine.SetPosition(1, hit.point);
            }

            //lazerLine.SetPosition(1, (playerCamrea.transform.forward * lazerRange));

            /*
            Vector3 rayOrigin = playerCamrea.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            Ray ray = new Ray(rayOrigin, playerCamrea.transform.forward);
            if(Physics.Raycast(ray, out RaycastHit hit, lazerRange))
            {
                lazerLine.SetPosition(1, hit.point);
            }
            else
            {
                lazerLine.SetPosition(1, (playerCamrea.transform.forward * lazerRange));
            }
            */

            lazerLine.enabled = true;
        }
    }

    

    IEnumerator EnableLazer()
    {
        lazerEnabled = true;
        yield return new WaitForSeconds(5.0f);
        lazerLine.enabled = false;
        lazerEnabled = false;
    }
}
