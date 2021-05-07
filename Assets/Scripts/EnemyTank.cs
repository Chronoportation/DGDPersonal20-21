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
    private GameManager gameManager;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    //called once per frame
    void FixedUpdate()
    {
        if (gameManager.isGameActive)
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
