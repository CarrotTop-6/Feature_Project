using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//12/1/23

public class Salvo : MonoBehaviour
{
    public Transform salvoSpawnPoint;
    public GameObject rocketPrefab;
    public float rocketSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            StartCoroutine(SpawnRocket());
        }
    }

    IEnumerator SpawnRocket()
    {
        for (int i = 0; i < 6; i++)
        {
            var _rocket = Instantiate(rocketPrefab, salvoSpawnPoint.position, salvoSpawnPoint.rotation);
            _rocket.GetComponent<Rigidbody>().velocity = salvoSpawnPoint.up * rocketSpeed;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
