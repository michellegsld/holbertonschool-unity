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
    private Animator currAnim;     // Usually called: anim

    private bool onPlatform = true;
    private bool isJumping = false;
    private bool isFalling = false;
    private bool canMove = true;
    public float speed = 10f;

    public GameObject pauseCanvas;
    public GameObject winCanvas;

    // For movement
    float turnSmoothVelocity;
    float speedSmoothVelocity;
    float currentSpeed;

    public int collisions = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set player, main camera, and animator
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
        // Main purpose: to reset canMove after FallingDown sub-state, which means it's not falling anymore
        if (Animator.StringToHash("Base Layer.Happy Idle") == currAnim.GetCurrentAnimatorStateInfo(0).fullPathHash)
        {
            canMove = true;
            isFalling = false;
        }

        if (canMove)
        {
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

            // Last part is 0.0f to rid of icy motion, magnitude to tell if it moved
            currentSpeed = Mathf.SmoothDamp(currentSpeed, speed * playerMove.magnitude, ref speedSmoothVelocity, 0.0f);

            player.transform.Translate(player.transform.forward * currentSpeed * Time.deltaTime, Space.World);

            // Now player can still move while jumping/falling w/o triggering movement animations
            if (!isJumping && !isFalling && onPlatform)
            {
                if (currentSpeed == 0)
                {
                    currAnim.SetTrigger("RunningToIdleTrigger");
                }
                else
                {
                    currAnim.SetTrigger("IdleToRunningTrigger");
                }
            }
        }

        // In order to change Jump animation into Falling animation
        if (player.transform.position.y <= -3 && isJumping)
        {
            currAnim.SetTrigger("JumpToFallingTrigger");

            isJumping = false;
            isFalling = true;
        }

        // Once the player hits a certain point, they will respawn
        if (player.transform.position.y <= -15)
        {
            player.transform.position = new Vector3(0, 15, 0);
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
        // For the user to jump, while they are on the platform and they can move
        if (Input.GetKey(KeyCode.Space) && onPlatform && canMove)
        {
            isJumping = true;

            Vector3 movement = new Vector3(0, 0.0F, 0) * speed * Time.deltaTime;
            movement.y = 5.5f;
            player.velocity = movement;
        }
    }

    // Called when the player collides with an object
    void OnCollisionEnter(Collision collision)
    {
        collisions++;

        // If they are not on a platform and collide with one
        if (onPlatform == false && collision.gameObject.tag == "Platform")
        {
            if (currentSpeed == 0 && isJumping)
            {
                currAnim.SetTrigger("JumpToIdleTrigger");
            }
            else if (isJumping)
            {
                currAnim.SetTrigger("JumpToRunningTrigger");
            }
            else if (canMove && isFalling)   // This means they hit the starter platform
            {
                canMove = false;
                currAnim.SetTrigger("FallingToImpactTrigger");
            }

            onPlatform = true;
            isJumping = false;
        }
    }

    // Called when the player is not touching another object anymore
    void OnCollisionExit(Collision collision)
    {
        collisions--;

        if (onPlatform && collision.gameObject.tag == "Platform")
        {
            onPlatform = false;
            if (currentSpeed == 0 && isJumping)
            {
                currAnim.SetTrigger("IdleToJumpTrigger");
            }
            else if (isJumping)
            {
                currAnim.SetTrigger("RunningToJumpTrigger");
            }
            else if (canMove && collisions == 0)
            {
                isFalling = true;
                currAnim.SetTrigger("RunningToFallingTrigger");
            }
        }
    }
}
