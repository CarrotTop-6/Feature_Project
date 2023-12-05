using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Creates an after effect explosion
//12/1/23

public class Explosion : MonoBehaviour
{
    private float expand = 0.5f;

    // Update is called once per frame
    void Start()
    {
        //after being spawned, rapdily expand to set size then delete
        StartCoroutine(ExpRadius());
    }

    IEnumerator ExpRadius()
    {
        while(this.transform.localScale.x < 3)
        {
            this.transform.localScale = this.transform.localScale + new Vector3(expand, expand, expand);
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(this.gameObject);
    }
}
