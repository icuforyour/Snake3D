using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;

    private void Update()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.z = Target.position.z;
        transform.position = cameraPosition + offset;
    }
}