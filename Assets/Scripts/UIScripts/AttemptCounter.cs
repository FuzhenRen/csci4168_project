/*
    This script allows player can see how many times they have tried.
*/
using UnityEngine;
using TMPro;

public class AttemptsCounter : MonoBehaviour
{
    private TextMeshProUGUI attemptsText; 
    private int attempts;                 // as a counter

    private void Awake()
    {
        attemptsText = GetComponent<TextMeshProUGUI>();
        ResetAttempts(); // at the first time respawn it is 1
    }

    // add once attempt time for each attempt
    public void AddAttempt()
    {
        attempts++;
        UpdateAttemptsDisplay();
    }

    // reset attempts text for each new map
    public void ResetAttempts()
    {
        attempts = 1;
        UpdateAttemptsDisplay();
    }

    // update the text.
    private void UpdateAttemptsDisplay()
    {
        attemptsText.text = "Attempts: " + attempts;
    }
}
