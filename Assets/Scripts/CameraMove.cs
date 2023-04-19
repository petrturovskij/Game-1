using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour

{
    public Transform cameraPoz;
    void Update()
    {
        transform.position = cameraPoz.position;
    }
}
