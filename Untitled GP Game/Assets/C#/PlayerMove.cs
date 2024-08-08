using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    //(Potato Code, 2022)

    public Rigidbody rBody;
    public GameObject camDisplay;
    public float speed, sensitivity, maxForce, jumpingForce;
    public Vector2 move, look;
    public float lookRoatation;
    public bool grounded;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();   
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
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
    
    void Jumping()
    {
        Vector3 jumpingForces = Vector3.zero;
        
        if (grounded)
        {
            jumpingForces = Vector3.up * jumpingForce;
        }

        rBody.AddForce(jumpingForces, ForceMode.VelocityChange);
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
