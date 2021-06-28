using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 14.5f;

    // Update is called once per frame
    void Update()
    {
        //continuously move object forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}