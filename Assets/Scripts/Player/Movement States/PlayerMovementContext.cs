using UnityEngine;

public class PlayerMovementContext : AbstractContext
{
    public SharedPlayerContext SharedCtx { get; } 
    public float RunSpd { get; }
    public Rigidbody2D Rb { get; }
    public KeyboardDirectionalInput InputHandler { get; }

    public PlayerMovementContext(GameObject gameObject, SharedPlayerContext sharedCtx, float runSpd, Rigidbody2D rb, KeyboardDirectionalInput inputHandler)
    {
        RunSpd = runSpd;
        Rb = rb;
        InputHandler = inputHandler;
        GameObject = gameObject;
        SharedCtx = sharedCtx;
    }
}
