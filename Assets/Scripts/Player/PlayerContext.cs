using UnityEngine;

public class PlayerContext
{
    public float RunSpd { get; }
    public Animator Animator { get; }
    public Rigidbody2D Rb { get; }
    public KeyboardDirectionalInput InputHandler { get; }

    public PlayerContext(float runSpd, Rigidbody2D rb, Animator animator, KeyboardDirectionalInput inputHandler)
    {
        RunSpd = runSpd;
        Rb = rb;
        Animator = animator;
        InputHandler = inputHandler;
    }
}
