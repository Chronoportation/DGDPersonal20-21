using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public new Transform camera;

    // Update is called once per frame
    void LateUpdate()
    {
        //attached object will look towards the camera
        transform.LookAt(transform.position + camera.forward);
    }
}
