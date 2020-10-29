using System;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Class for pausing the game
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    private static Stopwatch timer;
    public AudioMixerSnapshot play;
    public AudioMixerSnapshot paused;

    // Update is called once per frame
    void Update()
    {
        // If user presses ESC while pause menu is open
        if (Input.GetKeyDown("escape"))
        {
            Resume();
        }
    }

    // Pauses the game
    public void Pause()
    {
        // Sets Time Scale to 0 to "freeze" any movement
        Time.timeScale = 0;

        paused.TransitionTo(0.0f);

        // Sets camera turn speed to 0 to prevent looking around
        CameraController.turnSpeed = 0;

        if (Timer.timer != null)
        {
            // Pause the timer
            Timer.timer.Stop();
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
        // Activates Time Scale to normal value
        Time.timeScale = 1;

        play.TransitionTo(0.0f);

        // Sets camera turn speed to 1 to resume looking around
        CameraController.turnSpeed = 1;

        if (Timer.timer != null)
        {
            // Resumes the timer
            Timer.timer.Start();
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
