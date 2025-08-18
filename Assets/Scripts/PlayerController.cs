using System;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float runSpd;
    [SerializeField] private PlayerAttacker attack;
    [SerializeField] private Animator animator; 

    private Vector3 input;
    private bool isMoving;
    private bool isAttacking;
    private Rigidbody2D rb;
    private KeyboardInput inputHandler;
    private PlayerMovement move;
    private PlayerStates currentState;
    
    public enum PlayerStates
    {
        IdleState,
        WalkState,
        attackState
    }

    void Awake()
    {
        currentState = PlayerStates.IdleState; 
        rb = GetComponent<Rigidbody2D>();
        inputHandler = new KeyboardInput();
        move = new PlayerMovement(rb, runSpd);
    }

    // Update is called once per frame
    void Update()
    {
        input = inputHandler.getMovementInput();

        isAttacking = Input.GetKeyDown(KeyCode.Z);

        move.Move(input);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //animator.SetBool("isAttacking", true);
            attack.Attack();
        }

        if (input != new Vector3(0, 0))
        {
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        animator.SetBool("isMoving", isMoving);
    }
    
}
