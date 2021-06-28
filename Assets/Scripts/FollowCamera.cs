using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public new GameObject camera;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //object's position will follow the camera and adjusted based off the given offset
        transform.position = camera.transform.position + offset;
    }
}
