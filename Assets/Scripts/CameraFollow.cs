using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothing = 12.0f;

    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 aimPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, aimPos, smoothing*Time.deltaTime);
        transform.position = smoothedPos;
        transform.LookAt(target);
    }
}
