using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for controlling the Player
public class PlayerController : MonoBehaviour
{
    [SerializeField]    // In order to see it in the inspector
    private Rigidbody player;

    private bool onPlatform = true;
    public float speed = 10f;
    public float jump = 120f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();

        // To use the back button in the options menu
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        //inputVector = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed); //(OLD) Keys inputed

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 playerMove = new Vector3(x, 0f, z).normalized * speed * Time.deltaTime;
        player.transform.Translate(playerMove, Space.Self);

        if (player.transform.position.y <= -10)
        {
            player.transform.position = new Vector3(0, 10, 0);
        }
    }

    // Called according to the framerate
    private void FixedUpdate()
    {
        //player.velocity = inputVector; //(OLD) Move player according to keys inputed before
        if (Input.GetKey(KeyCode.Space) && onPlatform == true)
        {
            //player.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
            player.AddForce(Vector3.up * jump);
        }
    }

    // Called when the player collides with an object
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
            onPlatform = true;
    }

    // Called when the player is not touching another object anymore
    void OnCollisionExit(Collision collision)
    {
        onPlatform = false;
    }
}
