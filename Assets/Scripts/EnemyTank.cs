using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    private int maxHealth = 3;
    private int currentHealth;
    private float speed = 5.5f;
    private float minDistance = 15.0f;
    private float maxDistance = 25.0f;
    private Vector3 playerDirection;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    //called once per frame
    void FixedUpdate()
    {
        //destroy enemy if health is zero
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }

        //always look to the player
        transform.LookAt(player.transform);

        //move towards the player if the player is within the minimum distance
        if (Vector3.Distance(transform.position, player.transform.position) <= minDistance)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        //shoot at the player if the player is within the maximum distance
        if (Vector3.Distance(transform.position, player.transform.position) <= maxDistance)
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            currentHealth--;
            Destroy(collision.gameObject);
        }
    }
}
