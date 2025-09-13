using UnityEngine;

public class PlayerContext : AbstractContext
{
    public float RunSpd { get; }
    public Rigidbody2D Rb { get; }
    public KeyboardInput InputHandler { get; }
    public Animator Animator { get; }

    public PlayerContext(GameObject gameObject, Animator animator, float runSpd, Rigidbody2D rb, KeyboardInput inputHandler)
    {
        Animator = animator;
        RunSpd = runSpd;
        Rb = rb;
        InputHandler = inputHandler;
        GameObject = gameObject;

    }
}
