using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class to enable Timer script on initial player movement
public class TimerTrigger : MonoBehaviour
{
    public Timer timerScript;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       timerScript = player.GetComponent<Timer>();
    }

    // When player first moves
    void OnTriggerExit(Collider collider)
    {
        timerScript.enabled = true;
        // This was when this function was OnColliderExit instead of trigger
        // Re-enabled as when hit flag then fall, if move then continues timer
        gameObject.SetActive(false);    // When player reset, would land on top of this
    }
}
