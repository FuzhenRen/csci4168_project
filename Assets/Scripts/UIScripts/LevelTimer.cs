/*
    Simple timer control unit
*/
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    private TextMeshProUGUI timerText;   
    private float timer;                 
    private bool isRunning; // check the timer is running or not.

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        ResetTimer(); //reset timer every start
    }

    private void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    //reset timer
    public void ResetTimer()
    {
        timer = 0f;
        isRunning = true;
        UpdateTimerDisplay();
    }

    // stop timer
    public void StopAndRecordTime()
    {
        isRunning = false;
    }

    // update timer
    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }
}
