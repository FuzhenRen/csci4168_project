/*
    This is Script allow player get a speedup once player hit the yellow cube in the map.
    It allows player get 5-sec speed-up at 1.3 times faster.
*/
using UnityEngine;
using TMPro;
using System.Collections;

public class DoubleTime : MonoBehaviour
{
    public float speedBoostDuration = 5f;    
    public float speedMultiplier = 1.3f;       
    private TextMeshProUGUI SpeedUpMsg;     

    private void Start()
    {
        SpeedUpMsg = GameObject.Find("SpeedUpMsg")?.GetComponent<TextMeshProUGUI>();

        if (SpeedUpMsg != null)
        {
            Debug.Log("SpeedUpMsg found successfully.");
            SpeedUpMsg.gameObject.SetActive(false); // Set message invisble.
        }
        else
        {
            Debug.LogError("SpeedUpMsg not found. Please check the name in the Hierarchy.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                StartCoroutine(ApplySpeedBoost(playerController));
            }
        }
    }

    private IEnumerator ApplySpeedBoost(PlayerController playerController)
    {
        float originalSpeed = playerController.moveSpeed;
        playerController.moveSpeed *= speedMultiplier;

        // Display message
        if (SpeedUpMsg != null)
        {
            SpeedUpMsg.gameObject.SetActive(true);
            SpeedUpMsg.text = "*Speed up";
            Debug.Log("Displaying SpeedUpMsg.");
        }

        yield return new WaitForSeconds(speedBoostDuration);

        // back to original speed
        playerController.moveSpeed = originalSpeed;

        // hide message
        if (SpeedUpMsg != null)
        {
            SpeedUpMsg.gameObject.SetActive(false);
            Debug.Log("Hiding SpeedUpMsg.");
        }
    }
}
