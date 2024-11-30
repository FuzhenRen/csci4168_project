/*
    This is a capsule that moves forward and backward along the ground. 
    Once the player touches this capsule, they will be respawned.
*/
using UnityEngine;

public class WitchControllor : MonoBehaviour
{
    public float moveSpeed = 4f;      // Movement speed
    public float moveDistance = 3f;  // Maximum movement distance (forward and backward)

    private Vector3 startPosition;   // Initial position of the capsule
    private float moveDirection = 1f; // Movement direction (1 for forward, -1 for backward)
    private float currentMoveDistance; // Current movement progress

    private PlayerSpawner playerSpawner; // Reference to PlayerSpawner script

    private void Start()
    {
        // Find the PlayerSpawner object
        playerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();
        startPosition = transform.position; // Save the starting position
    }

    private void Update()
    {
        // Calculate movement distance
        currentMoveDistance += moveDirection * moveSpeed * Time.deltaTime;

        // Reverse direction when the capsule reaches the moveDistance limit
        if (currentMoveDistance >= moveDistance || currentMoveDistance <= -moveDistance)
        {
            moveDirection *= -1;
        }

        // Move the capsule along the Z-axis (forward and backward)
        transform.position = startPosition + new Vector3(0.0f, 0.0f, currentMoveDistance);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Respawn the player when they touch the capsule
            if (playerSpawner != null)
            {
                playerSpawner.SpawnPlayer();
            }
        }
    }
}
