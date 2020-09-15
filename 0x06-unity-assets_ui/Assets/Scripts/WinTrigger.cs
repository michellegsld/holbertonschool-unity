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

    // Start is called before the first frame update
    void Start()
    {
       timerScript = player.GetComponent<Timer>();
    }

    // When player touches flag
    void OnTriggerEnter(Collider collider)
    {
        timerScript.enabled = false;
        timerText.fontSize = 80;
        timerText.color = Color.green;
    }
}
