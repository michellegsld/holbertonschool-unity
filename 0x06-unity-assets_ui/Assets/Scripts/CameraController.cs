using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to control main camera
public class CameraController : MonoBehaviour
{
    // How fast the mouse turns
    public float turnSpeed = 1;

    private Transform target, player;
    float mouseX, mouseY;

    // To invert the Y axis
    public bool isInverted;

    // Start is called before the first frame update
    void Start()
    {
        target = this.transform.parent;
        player = target.transform.parent;

        Cursor.visible = false; // To not see mouse cursor
        Cursor.lockState = CursorLockMode.Locked;   // For mouse cursor to stay in center of screen
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Assign the mouse inputs
        mouseX += Input.GetAxis("Mouse X") * turnSpeed;
        if (isInverted)
        {
            mouseY += Input.GetAxis("Mouse Y") * turnSpeed;
        }
        else
        {
            mouseY -= Input.GetAxis("Mouse Y") * turnSpeed;
        }

        // Clamp the vertical rotation, so mouse doesn't flip around
        // Middle value is like how low it can go
        mouseY = Mathf.Clamp(mouseY, -10, 60);

        // rotate the camera
        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
