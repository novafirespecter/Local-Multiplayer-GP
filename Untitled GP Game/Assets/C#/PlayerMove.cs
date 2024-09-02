using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    //(Potato Code, 2022)

    [Header("Movement & Camera")]
    public Rigidbody rBody;
    public GameObject camDisplay;
    public float speed, sensitivity, gamepadSensitivity, maxForce, jumpingForce;
    public Vector2 move, look, lookGamepad;

    [Header("Rotation")]
    public float lookRoatation;

    [Header("Grounded")]
    public bool grounded;

    [Header("Audio")]
    public AudioSource footstepSound;

    // private Animator animator;
    // bool isRunning;
    // bool isJumping;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();   
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }
    public void OnLookGamepad(InputAction.CallbackContext context)
    {
        lookGamepad = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        Jumping();
    }
    private void FixedUpdate() 
    {
        Movement();
    }

    void Movement()
    {
        //find target velocity
        Vector3 currentVelocity = rBody.velocity;
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y);
        targetVelocity *= speed;

        //align direction
        targetVelocity = transform.TransformDirection(targetVelocity);

        //Calculate forces
        Vector3 velocityChange = targetVelocity - currentVelocity;
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);

        //limit force
        Vector3.ClampMagnitude(velocityChange, maxForce);
        rBody.AddForce(velocityChange, ForceMode.VelocityChange);
        
        // if (move.x != 0 || move.y != 0)
        // {
        //     isRunning = true;
        // }
        // else {isRunning = false;}
            
        // animator.SetBool("isRunning", isRunning);

                    // Play footstep sound when moving
        if (footstepSound && move.x != 0 || move.y != 0 && !footstepSound.isPlaying)
        {
            footstepSound.Play();
        }
        else if (footstepSound && move.x != 0 || move.y ! == 0)
        {
            footstepSound.Stop();
        }
    }
    
    void Looking()
    {
        //Turning
        transform.Rotate(Vector3.up * look.x * sensitivity);

        //Look
        lookRoatation += -look.y * sensitivity;
        lookRoatation = Mathf.Clamp(lookRoatation, -90, 90);
        camDisplay.transform.eulerAngles = new Vector3(lookRoatation, camDisplay.transform.eulerAngles.y, camDisplay.transform.eulerAngles.z);
    }

    void LookingGamepad()
    {
        //Turning
        transform.Rotate(Vector3.up * lookGamepad.x * gamepadSensitivity);

        //Look
        lookRoatation += -lookGamepad.y * gamepadSensitivity;
        lookRoatation = Mathf.Clamp(lookRoatation, -90, 90);
        camDisplay.transform.eulerAngles = new Vector3(lookRoatation, camDisplay.transform.eulerAngles.y, camDisplay.transform.eulerAngles.z);
    }
    
    void Jumping()
    {
        Vector3 jumpingForces = Vector3.zero;
        
        if (grounded)
        {
            jumpingForces = Vector3.up * jumpingForce;
            // isJumping = true;
        }
        else
        {
            // isJumping = false;
        }

        rBody.AddForce(jumpingForces, ForceMode.VelocityChange);

        // animator.SetBool("isJumping", isJumping);
    }

    private void Awake() 
    {
        // animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Looking();
        LookingGamepad();
    }

    private void Update()
    {
       Debug.DrawRay(transform.position, Vector3.forward, Color.green);  
    }

    public void SetGrounded( bool state)
    {
        grounded = state;
    }
}

// Name: PotatoHead
// Title: How To Make a Rigidbody Play Controller with Unity's Input System
// Source: Youtube
// Date: 15 May 2022
