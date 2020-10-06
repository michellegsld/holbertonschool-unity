﻿using System.Collections;
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
        mainCamera = player.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
    }

    // Function called by animation event (end of Intro01)
    void StartGame()
    {
        mainCamera.SetActive(true);                             // Enables Main Camera
        player.GetComponent<PlayerController>().enabled = true; // Enables PlayerController script
        timerCanvas.gameObject.SetActive(true);                 // Enables Timer Canvas
        cutsceneCamera.gameObject.SetActive(false);             // Disables Cutscene Camera
    }
}