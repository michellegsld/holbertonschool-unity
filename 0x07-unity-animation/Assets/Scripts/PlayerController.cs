using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class for controlling the Player
public class PlayerController : MonoBehaviour
{
    [SerializeField]    // In order to see it in the inspector
    private Rigidbody player;
    private Transform mainCam;
    [SerializeField]
    private Animator currAnim;

    private bool onPlatform = true;
    public float speed = 10f;

    public GameObject pauseCanvas;
    public GameObject winCanvas;

    // For movement
    float turnSmoothVelocity;
    float speedSmoothVelocity;
    float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        mainCam = Camera.main.transform;
        currAnim = player.transform.GetChild(0).gameObject.GetComponent<Animator>();

        // To use the back button in the options menu
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);

        // Activates Time Scale to normal value
        Time.timeScale = 1;

        // Sets camera turn speed to 1 to resume looking around
        CameraController.turnSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //inputVector = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed); //(OLD) Keys inputed

        // Controls player movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 playerMove = new Vector3(x, 0f, z).normalized;

        // If input is greater than 0
        if (playerMove != Vector3.zero)
        {
            float playerRotation = Mathf.Atan2(playerMove.x, playerMove.z) * Mathf.Rad2Deg + mainCam.eulerAngles.y;
            player.transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(player.transform.eulerAngles.y, playerRotation, ref turnSmoothVelocity, 0.0f); // 0.05f to immediately turn w/o circling
        }

        // Last part is 0.0f to rid of icy motion
        currentSpeed = Mathf.SmoothDamp(currentSpeed, speed * playerMove.magnitude, ref speedSmoothVelocity, 0.0f);

        player.transform.Translate(player.transform.forward * currentSpeed * Time.deltaTime, Space.World);

        if (currentSpeed == 0 && onPlatform)
        {
            currAnim.SetTrigger("RunningToIdleTrigger");
        }
        else if (onPlatform)
        {
            currAnim.SetTrigger("IdleToRunningTrigger");
        }

        // If player falls off platform
        if (player.transform.position.y <= -10)
        {
            // The player will respawn
            player.transform.position = new Vector3(0, 10, 0);
        }

        // Opens pause menu
        if (Input.GetKeyDown("escape") && winCanvas.gameObject.activeSelf == false)
        {
            pauseCanvas.GetComponent<PauseMenu>().Pause();
        }
    }

    // Called according to the framerate
    private void FixedUpdate()
    {
        //player.velocity = inputVector; //(OLD) Move player according to keys inputed before
        if (Input.GetKey(KeyCode.Space) && onPlatform == true)
        {
            // (OLD) player.AddForce(Vector3.up * jump);
            Vector3 movement = new Vector3(0, 0.0F, 0) * speed * Time.deltaTime;
            movement.y = 5.5f;
            player.velocity = movement;
        }
    }

    // Called when the player collides with an object
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            onPlatform = true;
            if (currentSpeed == 0)
            {
                currAnim.SetTrigger("JumpToIdleTrigger");
            }
            else
            {
                currAnim.SetTrigger("JumpToRunningTrigger");
            }
        }
    }

    // Called when the player is not touching another object anymore
    void OnCollisionExit(Collision collision)
    {
        onPlatform = false;

        if (currentSpeed == 0)
        {
            currAnim.SetTrigger("IdleToJumpTrigger");
        }
        else
        {
            currAnim.SetTrigger("RunningToJumpTrigger");
        }
    }
}
