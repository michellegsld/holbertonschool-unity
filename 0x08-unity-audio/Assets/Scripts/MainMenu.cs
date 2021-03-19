using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Controls everything in the main menu
public class MainMenu : MonoBehaviour
{
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        // To use the back button in the options menu
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);

        // To keep volume settings across different play sessions
        mixer.SetFloat("BGMVol", PlayerPrefs.GetFloat("BGMVol"));
        mixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
    }

    // To load levels 1-3
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene("Level0" + level.ToString());
    }

    // To open the options menu
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    // To Exit the game
    public void Exit()
    {
        Application.Quit();
    }
}
