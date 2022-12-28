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
    public float walkSpeed = 10f;//Movement speed           移动速度
    public float runSpeed = 15f;//Running speed             奔跑速度
    public float speed;
    public Vector3 moveDriction;//Setting the direction of movement             设置移动方向
    public bool isRun;

    //Jump                  跳跃
    public float jumpForce = 3f;//The force of jumping          跳跃的力
    public Vector3 velocity;//Force                             力
    private bool isJump;
    
    public float gravity = -25f;//Gravity                       重力
    private Transform groundCheck;
    private float groundDistance = 0.1f;
    public LayerMask groundMash;
    private bool isGround;

    [SerializeField] private float slopeForce = 6.0f;
    [SerializeField] private float slopeForceRayLenth = 2.0f;

    /*Setting the keys              设置键位*/
    [Header("Keyboard Setting")]
    [SerializeField]private KeyCode runInputName;//Running keys                     奔跑键位
    [SerializeField] private KeyCode jumpInputName;//Jump keys                      跳跃键位

    private void Start()
    {
        //Get the player's CharacterController component                            获取player的CharacterController组件
        characterController = GetComponent<CharacterController>();
        runInputName = KeyCode.LeftShift;
        jumpInputName = KeyCode.Space;
        groundCheck = GameObject.Find("Player/CheckGround").GetComponent<Transform>();
  
    }

    private void Update()
    {
        CheckGround();
        Move();
    }

    public void Move()
    {
        //Move and run                                                                   移动和奔跑
        float hor = Input.GetAxis("Horizontal");//Get horizontal axis shaft             获取水平轴轴体
        float ver = Input.GetAxis("Vertical");//Get the vertical axis shaft             获取垂直轴轴体
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

        //Jump                                                                                    跳跃
        if (isGround == false)//Not applying downward gravity on the ground (in the air)        不在地面上（空中）施加向下的重力
        {
            velocity.y += gravity * Time.deltaTime;
        }
        characterController.Move(velocity*Time.deltaTime);
        Jump();

        //If moving on a slope                                          如果在斜坡上移动
        if (OnSlope())
        {
            //Add a downward force                                      增加一个向下的力
            characterController.Move(Vector3.down * characterController.height / 2 * slopeForce * Time.deltaTime);
        }

    }

    public void Jump()
    {
        isJump = Input.GetKey(jumpInputName);

        if (isJump && isGround)
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

    //Detects if it is on a flat surface                                                        检测是否在平面上
    public bool OnSlope()
    {
        if (isJump)
            return false;
        //Send a ray downwards to check if it is on the slope                                       向下发出射线，检查是否在斜坡上
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