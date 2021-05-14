using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //face the nearest enemy
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Enemy").transform, Vector3.down);
        }
    }
}