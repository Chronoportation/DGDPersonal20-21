﻿using System.Collections;
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

    //check for collision 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            //destroy object
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Bullet") && collision.gameObject.CompareTag("Player"))
        {
            //destroy object
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Enemy Bullet") && collision.gameObject.CompareTag("Enemy"))
        {
            //destroy object
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet") ||collision.gameObject.CompareTag("Enemy Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
