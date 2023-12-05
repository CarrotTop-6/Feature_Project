using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float expand = 0.5f;

    // Update is called once per frame
    void Start()
    {
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
