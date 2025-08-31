using UnityEngine;

public class PlayerMovementContext : AbstractContext
{
    public float RunSpd { get; }
    public Animator Animator { get; }
    public Rigidbody2D Rb { get; }
    public KeyboardDirectionalInput InputHandler { get; }

    public PlayerMovementContext(GameObject gameObject, Animator animator, float runSpd, Rigidbody2D rb, KeyboardDirectionalInput inputHandler)
    {
        RunSpd = runSpd;
        Rb = rb;
        Animator = animator;
        InputHandler = inputHandler;
        GameObject = gameObject;
    }
}
