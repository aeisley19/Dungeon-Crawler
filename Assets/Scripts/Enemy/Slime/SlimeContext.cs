using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SlimeContext : SharedAliveObjectsContext
{
    public PlayerLocater Locater { get; }
    public Vector2 Dir { get; protected set; }

    public SlimeContext(GameObject gameObject, Animator animator, Rigidbody2D rb, Collider2D col,
        HealthManager health, DamageHandler damageHandler, PlayerLocater locater, Vector2 dir)
        : base(gameObject, rb, col, health, damageHandler, animator)
    {
        Locater = locater;
        Dir = dir;
    }
}