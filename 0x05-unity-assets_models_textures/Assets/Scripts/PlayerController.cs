using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]    // In order to see it in the inspector
    private Rigidbody player;

    private Vector3 inputVector;

    private bool canJump;
    public float speed = 10f;
    public float jump = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        //transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z)); <-make character look in direction it moving in
        if(Input.GetKeyUp(KeyCode.Space))
        {
            canJump = true;
        }
    }

    private void FixedUpdate()
    {
        player.velocity = inputVector;
        if(canJump)
        {
            canJump = false;
            player.AddForce(Vector3.up * Mathf.Sqrt(10f * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }
}
