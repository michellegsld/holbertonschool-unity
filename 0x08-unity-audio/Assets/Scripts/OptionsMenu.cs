using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Controls everything in the options menu
public class OptionsMenu : MonoBehaviour
{
    public Toggle invertToggle;
    public Slider BGM;
    public Slider SFX;

    void Start()
    {
        if (PlayerPrefs.GetInt("isInverted") == 1)
        {
            invertToggle.isOn = true;
        }
    }

    // To load the previous scene
    public void Back()
    {
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(sceneName);
    }

    // To apply changes and load previous scene
    public void Apply()
    {
        if (invertToggle.isOn == true)
        {
            PlayerPrefs.SetInt("isInverted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isInverted", 0);
        }

        // Call Back function to load previous scene
        Back();
    }
}
