using UnityEngine;

public abstract class SharedAliveObjectsContext : AbstractContext
{
    //public float RunSpd { get; protected set; }
    public Rigidbody2D Rb { get; protected set;  }
    public Collider2D Col { get; protected set;  } 
    public HealthManager Health { get; protected set; }
    public DamageHandler DamageHandler { get; protected set; }
    public Animator Animator { get; protected set; }

    public SharedAliveObjectsContext(GameObject gameObject, Rigidbody2D rb, Collider2D col, HealthManager health,
    DamageHandler damageHandler, Animator animator) : base(gameObject) 
    {
        Rb = rb;
        Col = col;
        Health = health;
        DamageHandler = damageHandler;
        Animator = animator;
    }
}
