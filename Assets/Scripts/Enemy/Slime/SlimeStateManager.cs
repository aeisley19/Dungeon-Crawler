using UnityEngine;
using System.Collections.Generic;
public enum SlimeStates
{
    IDLESTATE,
    MOVESTATE,
    DAMAGEDSTATE,
    APPROACHINGSTATE,
    PREPARETOATTACKSTATE,
    ATTACKSTATE,
    DEATHSTATE
} 

public class SlimeStateManager : AbstractStateManager<SlimeStates, SlimeContext>
{
    [SerializeField] private DamageHandler damageHandler;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D col;
    [SerializeField] private HealthManager health;
    [SerializeField] private float detectionRadius;
    [SerializeField] private float attackRadius;

    SlimeContext ctx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        ctx = new SlimeContext(gameObject, animator, rb, col, health, damageHandler, Vector2.zero, detectionRadius, attackRadius);

        states = new Dictionary<SlimeStates, AbstractState<SlimeStates, SlimeContext>>
        {
            { SlimeStates.IDLESTATE, new SlimeIdleState(ctx) },
            { SlimeStates.MOVESTATE, new SlimeMoveState(ctx) },
            { SlimeStates.DAMAGEDSTATE, new SlimeDamagedState(ctx) },
            { SlimeStates.PREPARETOATTACKSTATE, new SlimePrepareToAttackState(ctx) },
            { SlimeStates.ATTACKSTATE, new SlimeAttackState(ctx) },
            { SlimeStates.DEATHSTATE, new SlimeDeathState(ctx) }
        };

        currentState = states[SlimeStates.IDLESTATE];

        base.Start();
    }
}
