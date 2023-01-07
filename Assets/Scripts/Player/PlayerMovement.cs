using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// control palyer's movement
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    public float walkSpeed = 10f;//Movement speed         
    public float runSpeed = 15f;//Running speed            
    public float speed;
    public Vector3 moveDriction;//Setting the direction of movement           
    public bool isRun;

    //Jump       
    public float jumpForce = 3f;//The force of jumping          
    public Vector3 velocity;//Force                            
    private bool isJump;
    
    public float gravity = -25f;//Gravity                     
    private Transform groundCheck;
    private float groundDistance = 0.1f;
    public LayerMask groundMash;
    private bool isGround;

    [SerializeField] private float slopeForce = 6.0f;
    [SerializeField] private float slopeForceRayLenth = 2.0f;

    /*Setting the keys*/
    [Header("Keyboard Setting")]
    [SerializeField]private KeyCode runInputName;//Running keys                  
    [SerializeField] private KeyCode jumpInputName;//Jump keys                    

    private void Start()
    {
        //Get the player's CharacterController component                          
        characterController = GetComponent<CharacterController>();
        runInputName = KeyCode.LeftShift;
        jumpInputName = KeyCode.Space;
        groundCheck = GameObject.Find("Player/CheckGround").GetComponent<Transform>();
  
    }

    private void Update()
    {
        //CheckGround();
        Move();
    }

    public void Move()
    {
        //Move and run                                                                   
        float hor = Input.GetAxis("Horizontal");//Get horizontal axis shaft             
        float ver = Input.GetAxis("Vertical");//Get the vertical axis shaft            
        isRun = Input.GetKey(runInputName);
        if (isRun)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        moveDriction = (transform.right * hor + transform.forward * ver).normalized;
        characterController.Move(moveDriction*speed*Time.deltaTime);

        //Jump                                                                                
        if (characterController.isGrounded == false)//Not applying downward gravity on the ground (in the air)      
        {
            velocity.y += gravity * Time.deltaTime;
        }
        characterController.Move(velocity*Time.deltaTime);
        Jump();

        //If moving on a slope                                       
        if (OnSlope())
        {
            //Add a downward force        
            characterController.Move(Vector3.down * characterController.height / 2 * slopeForce * Time.deltaTime);
        }

    }

    public void Jump()
    {
        isJump = Input.GetKey(jumpInputName);

        if (isJump && characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    public void CheckGround()
    {
        
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMash);
        if (isGround && velocity.y <= 0)
        {
            velocity.y = -2f;
        }
    }

    //Detects if it is on a flat surface
    public bool OnSlope()
    {
        if (isJump)
            return false;
        //Send a ray downwards to check if it is on the slope
        if (Physics.Raycast(transform.position,new Vector3(0,-1,0),out RaycastHit hit, characterController.height/2*slopeForceRayLenth))
        {
            if(hit.normal != Vector3.up)
            {
                return true;
            }              
        }
        return false;
    }
}