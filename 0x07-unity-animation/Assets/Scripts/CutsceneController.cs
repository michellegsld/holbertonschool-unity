using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class that disables/enables what needs to be for the player to start
public class CutsceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    public GameObject player;
    public GameObject timerCanvas;
    public GameObject cutsceneCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Sets mainCamera to the first child of the first child of player
        mainCamera = player.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;

        Cursor.visible = false; // Set here although in CameraController because script is not initially enabled
                                // Not enabled for bug fix of camera jump from user input during Intro01
    }

    // Function called by animation event (end of Intro01)
    void StartGame()
    {
        mainCamera.SetActive(true);                             // Enables Main Camera
        mainCamera.GetComponent<CameraController>().enabled = true; // Enables CameraController script
        player.GetComponent<PlayerController>().enabled = true; // Enables PlayerController script
        timerCanvas.gameObject.SetActive(true);                 // Enables Timer Canvas
        cutsceneCamera.gameObject.SetActive(false);             // Disables Cutscene Camera
    }
}
