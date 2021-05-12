using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;


//maybe sprint to help with gameplay speed.
public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private Transform StartingPos;
    [SerializeField] private Transform groundCheck;
    public float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

        //Animations
    private Animator pAnim;

    private StatsManager pStats;


   
//Cam vars
    public float turnSmoothTime = 0.1f;
    public Transform cam;
    float turnSmoothVelocity;

     //Speed vars
    public float baseSpeed = 6f;
    public float sprintMod = 2f;
    public float buffSpeed;
    float currSpeed = 6f;
    //Jump
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

//Physics
    public Vector3 velocity;
    public Vector3 moveDir;
    
    bool isGrounded;

    //Input System
    float horizontal;
    float vertical;
    PlayerControls playerInput;

    private CharacterController controller;

    public void InitMovement(Transform incam) //Fill out later, but follows after Player initialization.
    {
        cam = incam;
        pStats = GetComponent<StatsManager>();
        buffSpeed = pStats.GetSpeed(baseSpeed);
    }
    private bool started;

    public void startmove(){
        started = true;
    }
    public void endmove(){
        started = false;
    }

    public void reset()
    {
        transform.position = StartingPos.position;
        transform.rotation = Quaternion.identity;
    }

    void Awake()
    {
        playerInput = new PlayerControls();
        playerInput.MovementMK.Horizontal.performed += ctx => horizontal = ctx.ReadValue<float>();
        playerInput.MovementMK.Vertical.performed += ctx => vertical = ctx.ReadValue<float>();
        playerInput.MovementMK.Sprint.performed += ctx => Sprint(ctx.ReadValue<float>());
        playerInput.MovementMK.Jump.performed += _ => Jump();

        controller = GetComponent<CharacterController>();
        pAnim = GetComponentInChildren<Animator>();

        //Debug
        started = true;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Anim: Grounded
        pAnim.SetBool("Grounded", isGrounded);

        if(isGrounded && velocity.y <0)
        {
            

            velocity.y = -2f;
        }

    //Vector 2 composite version, would work. Just switched it for a dumb misType.
    /*
        float horizontal = moveInput.x;
        float vertical = moveInput.y;
      */  

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude>=0.1f && started)
        {
            //Animation
            pAnim.SetBool("Moving", true);

            //Find movement direction based on camera
            float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //Arctan the player's direction, then add the cam's y rotation.
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            
            //move forward
            moveDir = moveDir.normalized * currSpeed;

            //Set velocity to movement
            velocity.x = moveDir.x;
            velocity.z = moveDir.z;
            
            //Anim: Speed
            pAnim.SetFloat("Speed", moveDir.magnitude/baseSpeed);
            float statSpeed = pStats.GetSpeed(baseSpeed);
            
            pAnim.SetFloat("Animation Speed", pStats.GetSpeed(baseSpeed)/baseSpeed);
        }
        else
        {
            //Animation
            pAnim.SetBool("Moving", false);

            velocity.x = 0f;
            velocity.z = 0f;
        }


        

        //Gravity
        velocity.y += gravity * Time.deltaTime;
        //Move
        controller.Move(velocity * Time.deltaTime); //d_y = .5G *t^2

        pAnim.SetFloat("FallSpeed", velocity.y);

        //reset sprint
            currSpeed = baseSpeed;
    }

    void Sprint(float read)
    {
        if(read>=1)
            currSpeed = baseSpeed * sprintMod;
        //Reverse is set each frame, ugh.
    }

    void Jump()
    {
        if(isGrounded && velocity.y <=0 && started)
        {
            //animation
            pAnim.SetTrigger("Jumping");

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity );
        }
        
    }

     void OnControllerColliderHit(ControllerColliderHit other) 
     {
        
     }



     //TEMP: Enable movement holder 
        //In the future, make an entire input script just for input values, and then let state machines happen on each script
    private void OnEnable() {
        playerInput.Enable();

    }

    private void OnDisable() {
        playerInput.Disable();
    }

 
}