using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform player;
    private AudioSource spawnerAudio;
    public AudioClip shootSound;
    private float cooldown = 100f;
    private float currentCooldown = 100f;
    private float maxDistance = 25.0f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //set up companion objects/components
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawnerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            if (Vector3.Distance(transform.position, player.transform.position) <= maxDistance && currentCooldown >= cooldown)
            {
                //launch bullet
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                //reset cooldown
                currentCooldown = 0;
                //play sound effect
                spawnerAudio.PlayOneShot(shootSound, 0.45f);
            }
            //add to currentCooldown
            currentCooldown += 0.5f;
        }
    }
}
