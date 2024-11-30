/*
    This is kind of capsule that once player touchs this bullet kind thing, they will be respwan.
*/
using UnityEngine;

public class DangerCapsule : MonoBehaviour
{
    public float moveSpeed = 4f;      
    public float moveDistance = 3f;   

    private Vector3 startPosition;
    private float moveDirection = 1f; 
    private float currentMoveDistance;

    private PlayerSpawner playerSpawner;

    private void Start()
    {
        playerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();
        startPosition = transform.position;
    }

    private void Update()
    {
        // cube movements
        currentMoveDistance += moveDirection * moveSpeed * Time.deltaTime;

        if (currentMoveDistance >= moveDistance || currentMoveDistance <= -moveDistance)
        {
            moveDirection *= -1;
        }

        transform.position = startPosition + new Vector3(currentMoveDistance, 0.0f, 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // respwan player
            if (playerSpawner != null)
            {
                playerSpawner.SpawnPlayer();
            }
        }
    }
}
