using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overall_movement : MonoBehaviour
{
    public CharacterController Controller;
    public Transform playerCamera; // Reference to the player's camera
    public float movespeed = 10f;
    public float gravity = -9.81f;
    public float jumpheight = 2f;
    public float runspeed = 5f;

    //input
    float x, y;
    bool sprinting, crouching;

    //Crouch
    private Vector3 playerscale;
    private Vector3 crouchscale = new Vector3(1, 0.5f, 1);

    //Grounded
    public Transform GroundCheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    bool checkground;

    Vector3 velocity; //declared velocity


    void Start()
    {
        playerscale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * X + transform.forward * Z;
        velocity.y += gravity * Time.deltaTime; //declared full velocity

        // Make Them MOVE!!
        Controller.Move(movespeed * move * Time.deltaTime); //move on ground
        Controller.Move(velocity * Time.deltaTime); //fall with gravity

        checkground = Physics.CheckSphere(GroundCheck.position, grounddistance, groundmask); //check ground by using CheckSphere method
        if (checkground && velocity.y < 0)
        {
            velocity.y = -2f; //reset velocity
        }

        // Jump
        if (Input.GetButtonDown("Jump") && checkground)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        // Sprinting
        sprinting = Input.GetKey(KeyCode.LeftShift);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movespeed = movespeed + runspeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
            movespeed = movespeed - runspeed;

        // Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
            StartCrouch();
        if (Input.GetKeyUp(KeyCode.LeftControl))
            Stopcrouch();

        // Adjust camera position when crouching
        if (crouching)
        {
            playerCamera.localPosition = new Vector3(playerCamera.localPosition.x, 0.5f, playerCamera.localPosition.z);
        }
        else
        {
            playerCamera.localPosition = new Vector3(playerCamera.localPosition.x, 1f, playerCamera.localPosition.z);
        }
    }

    // Crouch
    private void StartCrouch()
    {
        crouching = true;
        transform.localScale = crouchscale;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
    }

    private void Stopcrouch()
    {
        crouching = false;
        transform.localScale = playerscale;
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }
}