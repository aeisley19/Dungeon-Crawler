using UnityEngine;

public class PlayerAttackContext : AbstractContext
{
    public KeyboardAttackInput InputHandler { get; }
    public SharedPlayerContext SharedCtx{ get; }

    public PlayerAttackContext(GameObject gameObject, SharedPlayerContext sharedCtx, KeyboardAttackInput inputHandler)
    {
        InputHandler = inputHandler;
        GameObject = gameObject;
        SharedCtx = sharedCtx;
    } 
}
