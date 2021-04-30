using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0f, 15f, 0f);
    private float minX = -11.5f;
    private float maxX = 11.5f;
    private float minZ = -17.4f;
    private float maxZ = 17.4f;
    // Start is called before the first frame update
    void Start()
    {
        //make sure the camera is in the right spot before checking out the bounds
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //camera's position will be restricted to not go off the level
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, minX, maxX), transform.position.y, Mathf.Clamp(player.transform.position.z, minZ, maxZ));
    }
}