/* 
    This script allow players to get killed by red floor mat if they step on them.
    and respwan the player.
*/
using UnityEngine;

public class TouchDeath : MonoBehaviour
{
    private PlayerSpawner playerSpawner;

    private void Start()
    {
        playerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // respwan player by SpawnPlayer
            if (playerSpawner != null)
            {
                playerSpawner.SpawnPlayer();
            }
        }
    }
}
