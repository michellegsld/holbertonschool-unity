using System;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool currentlyPaused = false;

    private static Stopwatch timer;

    // Start is called before the first frame update
    void Start()
    {   }

    // Update is called once per frame
    void Update()
    {
        // Setting `timer` to `timer` in the Timer script
        timer = Timer.timer;

        if (Input.GetKeyDown("escape"))
        {
            if (currentlyPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Pauses the game
    public void Pause()
    {
        // Boolean in case user presses ESC again
        currentlyPaused = true;

        if (timer != null)
        {
            // Pause the timer
            timer.Stop();
        }

        // Display pause menu
        pauseCanvas.gameObject.SetActive(true);

        // To utilize mouse pointer
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Continues the game
    public void Resume()
    {
        // Boolean in case user presses ESC again
        currentlyPaused = false;

        if (timer != null)
        {
            // Resumes the timer
            timer.Start();
        }

        // Hides the pause menu
        pauseCanvas.gameObject.SetActive(false);

        // To set mouse pointer to game settings
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Start the current level over again
    public void Restart()
    {
        // Gets current scene
        Scene level = SceneManager.GetActiveScene();

        // Re-loads the current scene by getting its name
        SceneManager.LoadScene(level.name);
    }

    // Opens main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Opens options menu
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
