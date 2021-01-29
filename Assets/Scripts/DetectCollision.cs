using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //check for collision between two colliders
    private void OnTriggerEnter(Collider other)
    {
        //destroy object
        Destroy(gameObject);
    }
}
