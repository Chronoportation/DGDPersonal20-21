using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameObject explosionParticle;

    //check for collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            //create explosion
            Instantiate(explosionParticle, transform.position, transform.rotation);
            //destroy object
            Destroy(gameObject);
            
        }
        else if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Enemy Bullet"))
        {
            //create explosion
            Instantiate(explosionParticle, transform.position, transform.rotation);
            //destroy both objects
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            //destroy object
            Destroy(gameObject);
        }
    }
}
