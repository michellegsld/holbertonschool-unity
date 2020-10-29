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

        SetVolume();

        // Call Back function to load previous scene
        Back();
    }

    public void SetVolume()
    {
        float NewBGM = LinearToDecibel(BGM.value);
        float NewSFX = LinearToDecibel(SFX.value);

        mixer.SetFloat("BGMVol", NewBGM);
        mixer.SetFloat("SFXVol", NewSFX);

        PlayerPrefs.SetFloat("BGMVol", NewBGM);
        PlayerPrefs.SetFloat("SFXVol", NewSFX);
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
