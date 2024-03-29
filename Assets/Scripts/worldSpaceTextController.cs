﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldSpaceTextController : MonoBehaviour
{
    [SerializeField]
    private Camera cameraToLookAt;
    // Start is called before the first frame update
    void Start()
    {
        cameraToLookAt = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(cameraToLookAt.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}
