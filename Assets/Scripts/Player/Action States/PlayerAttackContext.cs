using UnityEngine;

public class PlayerAttackContext : AbstractContext
{
    public KeyboardAttackInput InputHandler { get; }
    public SharedPlayerContext SharedCtx{ get; }
    public ActionCooldown Cooldown { get; }

    public PlayerAttackContext(GameObject gameObject, SharedPlayerContext sharedCtx, KeyboardAttackInput inputHandler, ActionCooldown cooldown)
    {
        InputHandler = inputHandler;
        GameObject = gameObject;
        SharedCtx = sharedCtx;
        Cooldown = cooldown; 
    } 
}
