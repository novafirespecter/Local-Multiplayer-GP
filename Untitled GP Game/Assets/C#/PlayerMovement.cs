using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Animator animator; //Character Component
    int isWalking; //Parameter ID
    int isRunning; //Parameter ID

    PlayerCtrls input; //PlayerInput 

    Vector2 currentMove; //Player Input Values
    bool movePressed;
    bool runPressed;

    //Called when script instance is loaded
    void Awake()
    {
        input = new PlayerCtrls();

        // set input values using listeners
        input.CharacterCtrls.Movement.performed += ctx => {
            currentMove = ctx.ReadValue<Vector2>();
            movePressed = currentMove.x != 0 || currentMove.y != 0;
        };
        input.CharacterCtrls.Run.performed += ctx => runPressed = ctx.ReadValueAsButton();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Animator Ref
        animator = GetComponent<Animator>();

        //ID Ref
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
        handleRotate();
    }

    void handleRotate()
    {
        // current position of the character
        Vector3 currentPosition = transform.position;

        // the chnage in posistion the character should be looking at
        Vector3 newPosition = new Vector3(currentMove.x, 0, currentMove.y);
        
        // combine the posistions to give a position to look at
        Vector3 positionToLookAt = currentPosition + newPosition;

        // roatate the character to face the position to look at
        transform.LookAt(positionToLookAt);
    }

    void handleMovement()
    {
        // get parameter values from the animator
        bool isRunning = animator.GetBool(this.isRunning);
        bool isWalking = animator.GetBool(this.isWalking);

        // stops walking when move pressed is true and not walking
        if (movePressed && !isWalking)
        {
            animator.SetBool(this.isWalking, true);
        }

        // stops walking when move pressed is false and not walking
          if (!movePressed && isWalking)
        {
            animator.SetBool(this.isWalking, false);
        }

        // stops running when move pressed is true and not running
        if ((movePressed && runPressed) && !isRunning)
        {
            animator.SetBool(this.isRunning, true);
        }

        // stops running when move pressed is false and not running
        if ((!movePressed || !runPressed) && isRunning)
        {
            animator.SetBool(this.isRunning, false);
        }
    }

    void OnEnable()
    {
        // enables the controls action map
        input.CharacterCtrls.Enable();
    }

    void OnDisable()
    {
        // disable the controls action map
        input.CharacterCtrls.Disable();
    }


}
