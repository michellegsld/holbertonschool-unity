using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Changes display of timer once player hits flag
public class WinTrigger : MonoBehaviour
{
    public Text timerText;
    public Timer timerScript;
    public GameObject player;
    public GameObject timerCanvas;
    public GameObject winCanvas;

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

        // (OLD) before win canvas
        //timerScript.enabled = false;
        //timerText.fontSize = 80;
        //timerText.color = Color.green;
    }
}
