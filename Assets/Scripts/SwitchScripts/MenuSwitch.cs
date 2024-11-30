/*
    This script for load the scene from start menue to scene 1;
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Load the first sence.
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    //Quit the game.
    public void Quit()
    {
        Application.Quit();
    }

    // Load the main menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0); 
    }
}
