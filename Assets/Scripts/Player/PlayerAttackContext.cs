using UnityEngine;

public class PlayerAttackContext : AbstractContext
{
    public KeyboardAttackInput InputHandler { get; }
    public Animator Animator { get; }

    public PlayerAttackContext(GameObject gameObject, KeyboardAttackInput inputHandler, Animator animator)
    {
        InputHandler = inputHandler;
        Animator = animator;
        GameObject = gameObject;
    } 
}
