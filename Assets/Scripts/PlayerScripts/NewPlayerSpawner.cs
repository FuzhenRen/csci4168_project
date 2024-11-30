/*
    This script controlls player spwan and display the spwan massge after every player death.
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class NewPlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;
    public CameraController cameraController;
    private AttemptsCounter attemptsCounter;
    private bool isFirstSpawn = true; //message only display after player first respwan.
    private GameObject currentPlayer; //tracking for only one player prefab will be generated. 

    private TextMeshProUGUI RespawnMsg; // display and hide after player every new respwan.
    private TextMeshProUGUI LevelText; //levelText displays the current level player at.

    private void Awake()
    {
        RespawnMsg = GameObject.Find("RespawnMsg")?.GetComponent<TextMeshProUGUI>();
        LevelText = GameObject.Find("LevelText")?.GetComponent<TextMeshProUGUI>();

        if (RespawnMsg != null)
        {
            RespawnMsg.gameObject.SetActive(false);
        }

        UpdateLevelText();
    }

    private void Start()
    {
        GameObject attemptsUI = GameObject.Find("Attempts");
        if (attemptsUI != null)
        {
            attemptsCounter = attemptsUI.GetComponent<AttemptsCounter>();
            if (attemptsCounter != null)
            {
                attemptsCounter.ResetAttempts();
            }
        }

        SpawnPlayer();
        isFirstSpawn = false;
    }

    public void SpawnPlayer()
    {
        if (playerPrefab == null || spawnPoint == null)
        {
            Debug.LogError("PlayerPrefab or SpawnPoint is not assigned!");
            return;
        }

        if (currentPlayer != null)
        {
            Destroy(currentPlayer); // without this player will repwan a lot
        }

        currentPlayer = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        cameraController.SetPlayer(currentPlayer.transform);

        if (!isFirstSpawn && RespawnMsg != null)
        {
            StartCoroutine(ShowRespawnMessage());
        }

        if (!isFirstSpawn && attemptsCounter != null)
        {
            attemptsCounter.AddAttempt();
        }
    }

    // display 2-sec and hide message.
    private System.Collections.IEnumerator ShowRespawnMessage()
    {
        RespawnMsg.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        RespawnMsg.gameObject.SetActive(false);
    }

    // update level number
    private void UpdateLevelText()
    {
        if (LevelText != null)
        {
            int levelNumber = SceneManager.GetActiveScene().buildIndex; // get level index
            LevelText.text = "Level: " + levelNumber; // update dispalying
        }
    }
}
