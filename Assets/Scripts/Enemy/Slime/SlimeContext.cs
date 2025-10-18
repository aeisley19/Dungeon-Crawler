using UnityEngine;

public class SlimeContext : SharedAliveObjectsContext
{

    public SlimeContext(GameObject gameObject, Animator animator, Rigidbody2D rb, Collider2D col,
        HealthManager health, DamageHandler damageHandler)
    {
        GameObject = gameObject;
        DamageHandler = damageHandler;
        Animator = animator;
        Rb = rb;
        Col = col;
        Health = health;
    }
}