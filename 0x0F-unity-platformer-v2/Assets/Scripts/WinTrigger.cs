using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Changes display of timer once player hits flag
public class WinTrigger : MonoBehaviour
{
    public Timer timerScript;
    public GameObject player;
    public GameObject timerCanvas;
    public GameObject winCanvas;
    public AudioSource backgroundMusic;
    public AudioSource winMusic;

    // Start is called before the first frame update
    void Start()
    {
       timerScript = player.GetComponent<Timer>();
    }

    // When player touches flag
    void OnTriggerEnter(Collider collider)
    {
        // Update final win time
        timerScript.Win();

        // Hide the timer canvas
        timerCanvas.gameObject.SetActive(false);

        // Display the win canvas
        winCanvas.gameObject.SetActive(true);

        // Stop playing background music
        backgroundMusic.Stop();

        // Start playing the win music
        winMusic.Play();

        // In order to stop animations and player movement
        Time.timeScale = 0;

        // Stop camera movement on win
        Camera.main.transform.GetComponent<CameraController>().enabled = false;
    }
}
