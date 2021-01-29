using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float xBound = 25.0f;
    private float zBound = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xBound || transform.position.x < -xBound) //left and right
        {
            Destroy(gameObject);
        }
        else if (transform.position.z > zBound || transform.position.z < -zBound) //top and bottom
        {
            Destroy(gameObject);
        }
    }
}
