using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    private float horizontalInput;
    private float verticalInput;
    private float speed = 6.0f;
    private float turnSpeed = 100.0f;
    public HealthBar healthBar;
    public GameObject bulletPrefab;
    public GameObject[] collisionList;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    //for movement (called once per frame)
    void FixedUpdate()
    {
        //get inputs for movement
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

    //method to run when the player takes damage; will remove a given amount of health and adjust health bar respectively
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}