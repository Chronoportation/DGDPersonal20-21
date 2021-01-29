using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;
    private Vector3 offset = new Vector3(0f, 0.95f, 1.45f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //for shooting(called once per frame)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //launch bullet
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
