using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowBrick : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform
    public GameObject brickPrefab;  // Prefab of the brick
    public float throwForce = 10f;  // Force applied to the thrown brick
    public float detectionRange = 10f;  // Range within which the enemy can detect the player
    public float timer = 2f; // this is to make sure no new bricks are thrown except every 2 sec

    void Update()
    {
        // Check if the player is within the detection range
        if (player != null && Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            // Rotate the enemy to face the player
            transform.LookAt(player);

            // Invoke("ThrowBrick", 1);
            // Throw a brick

            ThrowBrick();
        }
    }

    void ThrowBrick()
    {
        Vector3 hmada = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        // Instantiate a new brick

        GameObject brick = Instantiate(brickPrefab, transform.position, Quaternion.identity);

        // GameObject brick = Instantiate(brickPrefab, transform.position, Quaternion.identity) as GameObject;

        // Get the rigidbody of the brick
        Rigidbody2D brickRigidbody = brick.GetComponent<Rigidbody2D>();

        // Apply force to the thrown brick
        if (brickRigidbody != null)
        {
            brickRigidbody.AddForce(transform.right * throwForce, ForceMode2D.Impulse); // hna ya amir
        }
    }
}

