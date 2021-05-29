using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvents : MonoBehaviour
{
    // Door animation
    public Animator DoorAnim;

    // Main Room Floors for Teleporting
    public GameObject FloorsTeleport;

    // The Player Object to detect door usage
    // public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        // Enables the floors to be teleported on in the Main Room
        if (DoorAnim.GetBool("unlocked") && DoorAnim.GetBool("handle_open")) {
            FloorsTeleport.SetActive(true);
        }
    }

    // Sets the character_nearby parameter to true
    public void PersonCloseToDoor()
    {
        DoorAnim.SetBool("character_nearby", true);
    }

    // Sets the character_nearby parameter to false
    public void PersonFarFromDoor()
    {
        DoorAnim.SetBool("character_nearby", false);
        DoorAnim.SetBool("handle_open", false);
    }

    // Sets the character_nearby parameter to true
    public void DoorHandleOpen()
    {
        DoorAnim.SetBool("handle_open", true);
    }

    // Sets the character_nearby parameter to false
    public void DoorHandleClose()
    {
        DoorAnim.SetBool("handle_open", false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other != null && other.tag != "Entry") {
            PersonCloseToDoor();
//            Debug.Log("In if enter");
        }
        Debug.Log("Out if enter");
    }

    private void OnTriggerExit(Collider other) {
        //if (other != null && other.tag == "Entry") {
            PersonFarFromDoor();
//            Debug.Log("In if");
        //}
        Debug.Log("Out if");
    }
}
