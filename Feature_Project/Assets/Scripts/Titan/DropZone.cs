using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Set the drop zone
//11/30/23

public class DropZone : MonoBehaviour
{
    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
    }
}
