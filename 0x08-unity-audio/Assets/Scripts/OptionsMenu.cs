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
    public AudioMixer mixer;

    void Start()
    {
        if (PlayerPrefs.GetInt("isInverted") == 1)
        {
            invertToggle.isOn = true;
        }

        BGM.value = DecibelToLinear(PlayerPrefs.GetFloat("BGMVol"));
        SFX.value = DecibelToLinear(PlayerPrefs.GetFloat("SFXVol"));
    }

    void Update()
    {
        ControlVolume();
    }

    // To load the previous scene
    public void Back()
    {
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        //ResetVolume();
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

        SetVolume();

        PlayerPrefs.Save();

        // Call Back function to load previous scene
        Back();
    }

    // In order to change volume as slider moves
    public void ControlVolume()
    {
        mixer.SetFloat("BGMVol", LinearToDecibel(BGM.value));
        mixer.SetFloat("SFXVol", LinearToDecibel(SFX.value));
    }

    // Actually saves the volume across scenes and exiting/opening application
    public void SetVolume()
    {
        PlayerPrefs.SetFloat("BGMVol", LinearToDecibel(BGM.value));
        PlayerPrefs.SetFloat("SFXVol", LinearToDecibel(SFX.value));
    }

    // Makes sure the volume stays where it was before the sliders were changed
    public void ResetVolume()
    {
        // This fixes the bug where slider change would persist across scenes
        // even if the "Back" button was pressed, but would correct itself
        // when the "Options" scene was opened again
        // vv OLD SOLUTION, would cause slider to reset before returning to previous scene
        // BGM.value = DecibelToLinear(PlayerPrefs.GetFloat("BGMVol"));
        // SFX.value = DecibelToLinear(PlayerPrefs.GetFloat("SFXVol"));

        mixer.SetFloat("BGMVol", PlayerPrefs.GetFloat("BGMVol"));
        mixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
    }

    private float LinearToDecibel(float linear)
    {
        if (linear != 0)
            return 20.0f * Mathf.Log10(linear);
        return -144.0f;
    }

    private float DecibelToLinear(float dB)
    {
        return Mathf.Pow(10.0f, dB / 20.0f);
    }
}
