using UnityEngine;

public class PlayerContext : SharedAliveObjectsContext
{
    public KeyboardInput InputHandler { get; }
    public HealthUI UI;
    public float RunSpd { get; }

    public PlayerContext(GameObject gameObject, Animator animator, float runSpd, Rigidbody2D rb, Collider2D col,
        KeyboardInput inputHandler, HealthManager health, DamageHandler damageHandler, HealthUI ui) 
        : base(gameObject, rb, col, health, damageHandler, animator)
    {
        RunSpd = runSpd;
        InputHandler = inputHandler;
        UI = ui;
    }
}
