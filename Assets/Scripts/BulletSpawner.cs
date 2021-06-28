using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;
    private AudioSource spawnerAudio;
    public AudioClip shootSound;
    private Vector3 offset = new Vector3(0f, 0.95f, 1.45f);
    private float cooldown = 30f;
    private float currentCooldown = 30f;

    // Start is called before the first frame update
    void Start()
    {
        //set up companion objects/components
        spawnerAudio = GetComponent<AudioSource>();
    }

    //for shooting(called once per frame)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentCooldown >= cooldown)
        {
            //launch bullet
            Instantiate(bulletPrefab, transform.position, transform.rotation);

            //reset cooldown
            currentCooldown = 0;

            //play sound effect
            spawnerAudio.PlayOneShot(shootSound, 0.75f);
        }
        //add to currentCooldown
        currentCooldown += 0.5f;
    }
}