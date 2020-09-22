using System;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // Pause the timer
        timer.Stop();

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

        // Resumes the timer
        timer.Start();

        // Hides the pause menu
        pauseCanvas.gameObject.SetActive(false);

        // To set mouse pointer to game settings
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
