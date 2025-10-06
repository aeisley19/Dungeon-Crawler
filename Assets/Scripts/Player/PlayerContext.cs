using UnityEngine;

public class PlayerContext : AbstractContext
{
    public float RunSpd { get; }
    public Rigidbody2D Rb { get; }
    public Collider2D Col { get; } 
    public KeyboardInput InputHandler { get; }
    public HealthManager Health { get; }
    public DamageHandler DamageHandler { get; } 
    public Animator Animator { get; }
    public HealthUI UI;

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
