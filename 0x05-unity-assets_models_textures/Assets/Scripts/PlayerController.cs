using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for controlling the Player
public class PlayerController : MonoBehaviour
{
    [SerializeField]    // In order to see it in the inspector
    private Rigidbody player;

    private Vector3 inputVector;

    private bool onPlatform = true;
    public float speed = 15f;
    public float jump = 100;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed); // Keys inputed
        //transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z)); <-make character look in direction it moving in
    }

    // Called according to the framerate
    private void FixedUpdate()
    {
        player.velocity = inputVector; // Move player according to keys inputed before
        if (Input.GetKey(KeyCode.Space) && onPlatform == true)
        {
            player.AddForce(new Vector3(0, jump, 0), ForceMode.VelocityChange);
        }
    }

    // Called when the player collides with an object
    void OnCollisionEnter(Collision collision)
    {
        // If the player is on a Platform
        if (collision.gameObject.transform.parent.name == "Platforms")
        {
            onPlatform = true;
        }
    }

    // Called when the player is not touching another object anymore
    void OnCollisionExit(Collision collision)
    {
        onPlatform = false;
    }
}
