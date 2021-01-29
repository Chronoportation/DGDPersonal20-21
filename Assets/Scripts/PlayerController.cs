using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 6.0f;
    private float turnSpeed = 100.0f;
    public GameObject bulletPrefab;
    public GameObject[] collisionList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //for movement (called once per frame)
    void FixedUpdate()
    {
        //get inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //move the player
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //rotate the player only when they are moving forward (that's how turning works)
        if (verticalInput != 0)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
    }

    //(called once per frame)
    void Update()
    {
        
    }

    //collision
    private void OnTriggerEnter(Collider other)
    {
        
    }
}