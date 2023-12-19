using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overall_movement : MonoBehaviour
{
    public CharacterController Controller;
    public float movespeed = 10f;
    public float gravity = -9.81f;
    public float jumpheight = 2f;
    public float runspeed = 5f;

    //input
    float x, y;
    bool sprinting, crouching;
    
    //Grounded
    public Transform GroundCheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    bool checkground;

    Vector3 velocity; //declared velocity
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * X + transform.forward * Z;
        velocity.y += gravity* Time.deltaTime; //declared full velocity


        //Make Them MOVE!!
        Controller.Move(movespeed * move * Time.deltaTime); //move onground
        Controller.Move(velocity * Time.deltaTime); //fall with gravity

        checkground = Physics.CheckSphere(GroundCheck.position, grounddistance, groundmask); //check ground by using CheckSphere method
        if(checkground && velocity.y < 0)
        {
            velocity.y = -2f; //reset velocity
        }

        //jump
        if (Input.GetButtonDown("Jump") && checkground)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        //sprinting
        sprinting = Input.GetKey(KeyCode.LeftShift);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movespeed = movespeed + runspeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
            movespeed = movespeed - runspeed;
    }
}
