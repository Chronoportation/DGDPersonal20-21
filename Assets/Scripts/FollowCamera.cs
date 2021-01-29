﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject camera;
    private Vector3 offset = new Vector3(-9.5f, -12.5f, 6.25f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camera.transform.position + offset;
    }
}