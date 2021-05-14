using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    private float horizontalInput;
    private float verticalInput;
    private float speed = 7.5f;
    private float turnSpeed = 120.0f;
    private bool readyForDamage = true;
    private AudioSource playerAudio;
    public AudioClip powerupSound;
    private Rigidbody rb;
    private GameManager gameManager;
    public HealthBar healthBar;
    public GameObject bulletPrefab;
    public GameObject explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        //set up health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //set up companion objects/components
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    //called once per frame regulated
    void FixedUpdate()
    {
        if (gameManager.isGameActive)
        {
            //check if player health is 0 to end the game
            if (currentHealth == 0)
            {
                gameManager.GameOver();
                Instantiate(explosionParticle, transform.position, transform.rotation);
            }

            //get inputs for movement
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            //move the player
            HandleMovement();
        }
    }

    //method to take care of the player's movement
    private void HandleMovement()
    {
        //move the player
        Vector3 wantedPos = transform.position + (transform.forward * verticalInput * speed * Time.deltaTime);
        rb.MovePosition(wantedPos);

        //rotate the player only when they are moving forward (that's how turning works)
        if (verticalInput != 0)
        {
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
    }

    //method to run when the player takes damage; will remove a given amount of health and adjust health bar respectively
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    //check for collisions (enemies)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && readyForDamage)
        {
            //set a countdown to prevent damage from building up
            readyForDamage = false;
            StartCoroutine(CollisionCountdown());
            TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("Enemy Bullet"))
        {
            if (readyForDamage)
            {
                readyForDamage = false;
                StartCoroutine(CollisionCountdown());
                TakeDamage(1);
            }

            Destroy(collision.gameObject);
        }
    }

    //check for trigger (powerups)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Health Powerup") && currentHealth < maxHealth)
        {
            //give one health point back to the player
            TakeDamage(-1);

            //destroy the powerup
            Destroy(other.gameObject);

            //play sound effect
            playerAudio.PlayOneShot(powerupSound, 0.75f);
        }
    }

    //run a cooldown so collision can't compound
    IEnumerator CollisionCountdown()
    {
        yield return new WaitForSeconds(0.5f);
        readyForDamage = true;
    }

}