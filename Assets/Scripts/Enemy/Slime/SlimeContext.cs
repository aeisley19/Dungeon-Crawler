using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SlimeContext : AbstractContext
{
    public DetectPlayerInsideBounds Detector { get; }
    public Vector2 MoveTowards { get; set; }
    public Rigidbody2D Rb { get; protected set;  }
    public Collider2D Col { get; protected set;  } 
    public HealthManager Health { get; protected set; }
    public DamageHandler DamageHandler { get; protected set; }
    public Animator Animator { get; protected set; }
    public float DetectionRadius { get; }
    public float AttackRadius { get; }
    public PlayerFinder FindPlayer { get; }

    public SlimeContext(GameObject gameObject, Animator animator, Rigidbody2D rb, Collider2D col,
        HealthManager health, DamageHandler damageHandler, Vector2 moveTowards, float detectionRadius,
        float attackRadius) : base(gameObject)
    {
        Detector = new DetectPlayerInsideBounds();
        FindPlayer = new PlayerFinder(gameObject, GameObject.Find("Player"));
        MoveTowards = moveTowards;
        Rb = rb;
        Col = col;
        Health = health;
        DamageHandler = damageHandler;
        Animator = animator;
        DetectionRadius = detectionRadius;
        AttackRadius = attackRadius;
    }
}