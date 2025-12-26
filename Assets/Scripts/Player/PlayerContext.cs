using UnityEngine;

public class PlayerContext : AbstractContext
{
    public KeyboardInput InputHandler { get; }
    public HealthUI UI;
    public float RunSpd { get; }
    public Rigidbody2D Rb { get; protected set;  }
    public Collider2D Col { get; protected set;  } 
    public HealthManager Health { get; protected set; }
    public DamageHandler DamageHandler { get; protected set; }
    public Animator Animator { get; protected set; }
    public RotateHitBox RotateHitBox { get; }

    public PlayerContext(GameObject gameObject, Animator animator, float runSpd, Rigidbody2D rb, Collider2D col,
        KeyboardInput inputHandler, HealthManager health, DamageHandler damageHandler, HealthUI ui, RotateHitBox rotateHitBox) 
        : base(gameObject)
    {
        RunSpd = runSpd;
        InputHandler = inputHandler;
        UI = ui;
        Rb = rb;
        Col = col;
        Health = health;
        DamageHandler = damageHandler;
        Animator = animator;
        RotateHitBox = rotateHitBox;
    }
}
