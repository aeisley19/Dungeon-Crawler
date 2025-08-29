using UnityEngine;

public class PlayerAttackContext
{
    public KeyboardAttackInput InputHandler { get; }
    public Animator Animator { get; }

    public PlayerAttackContext(KeyboardAttackInput inputHandler, Animator animator)
    {
        InputHandler = inputHandler;
        Animator = animator;
    } 
}
