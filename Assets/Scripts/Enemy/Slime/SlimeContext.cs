using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SlimeContext : AbstractContext
{
    public PlayerLocater Locater { get; }
    public Vector2 MoveTowards { get; set; }
    public Rigidbody2D Rb { get; protected set;  }
    public Collider2D Col { get; protected set;  } 
    public HealthManager Health { get; protected set; }
    public DamageHandler DamageHandler { get; protected set; }
    public Animator Animator { get; protected set; }

    public SlimeContext(GameObject gameObject, Animator animator, Rigidbody2D rb, Collider2D col,
        HealthManager health, DamageHandler damageHandler, PlayerLocater locater, Vector2 moveTowards) : base(gameObject)
    {
        Locater = locater;
        MoveTowards = moveTowards;
        Rb = rb;
        Col = col;
        Health = health;
        DamageHandler = damageHandler;
        Animator = animator;
    }
}