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
    private Rigidbody rb;
    public HealthBar healthBar;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //prep health info
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody>();
    }

    //called once per frame regulated
    void FixedUpdate()
    {
        //check if player health is 0 to end the game
        if (currentHealth == 0)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }

        //get inputs for movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //move the player
        HandleMovement();
    }

    private void HandleMovement()
    {
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Health Powerup") && currentHealth < maxHealth)
        {
            //give one health point back to the player
            TakeDamage(-1);

            //destroy the powerup
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy") && readyForDamage)
        {
            //set a countdown to prevent damage from building up
            readyForDamage = false;
            StartCoroutine(CollisionCountdown());
            TakeDamage(1);
        }
    }

    //run a cooldown so collision doesn't compound
    IEnumerator CollisionCountdown()
    {
        yield return new WaitForSeconds(1);
        readyForDamage = true;
    }

}