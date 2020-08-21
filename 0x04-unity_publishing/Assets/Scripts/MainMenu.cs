using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    public Button optionsButton;
    public Button backButton;
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayMaze);
        quitButton.onClick.AddListener(QuitMaze);

        optionsButton.onClick.AddListener(OpenOptions);
        backButton.onClick.AddListener(CloseOptions);
    }

    // Update is called once per frame
    void Update() {    }

    // Loads the maze scene when the Play button is pressed
    public void PlayMaze()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = new Color32(0, 255, 0, 1);
            goalMat.color = new Color32(255, 0, 0, 1);
        }
        SceneManager.LoadScene("maze");
    }

    // Closes the game window when Quit button is pressed
    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    // Displays Options Menu, hides Main Menu
    public void OpenOptions()
    {
        optionsMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    // Displays Main Menu, hides Options Menu
    public void CloseOptions()
    {
        optionsMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

}
