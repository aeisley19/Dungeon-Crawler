using UnityEngine;

public class PlayerContext : SharedAliveObjectsContext
{
    public KeyboardInput InputHandler { get; }
    public HealthUI UI;
    public float RunSpd { get; }

    public PlayerContext(GameObject gameObject, Animator animator, float runSpd, Rigidbody2D rb, Collider2D col,
        KeyboardInput inputHandler, HealthManager health, DamageHandler damageHandler, HealthUI ui)
    {
        Animator = animator;
        RunSpd = runSpd;
        Rb = rb;
        InputHandler = inputHandler;
        GameObject = gameObject;
        Health = health;
        DamageHandler = damageHandler;
        Col = col;
        UI = ui;
    }
}
