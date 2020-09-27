using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class for WinCanvas utility
public class WinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // To utilize mouse pointer
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Opens main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Loads the next level
    public void Next()
    {
        // Gets current scene
        Scene level = SceneManager.GetActiveScene();

        if (level.name == "Level01")
        {
            SceneManager.LoadScene("Level02");
        }
        else if (level.name == "Level02")
        {
            SceneManager.LoadScene("Level03");
        }
        else
        {
            MainMenu();
        }
    }
}
