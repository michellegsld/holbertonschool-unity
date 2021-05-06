// CURRENT PLAN:
// CREATE A UI SO THE PLAYER CAN TURN THIS ON OR OFF IN OPTIONS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// This class shows the controllers in the player's hands
// This script was found in this tutorial, at this time:
// https://youtu.be/5C6zr4Q5AlA?t=370
public class ShowControllers : MonoBehaviour
{
    public bool showController = false;

    // Update is called once per frame
    void Update()
    {
        // To access each hand
        foreach (var hand in Player.instance.hands) {
            if (showController) {   // if want to show controllers
                hand.ShowController();
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);  // To make the hand hold the controller realistically
            } else {                // if don't want to show controllers
                hand.HideController();
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithoutController);   // To stop holding the controllers
            }
        }
    }
}
