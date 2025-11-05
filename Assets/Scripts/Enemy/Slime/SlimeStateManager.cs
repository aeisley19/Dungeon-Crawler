using UnityEngine;
using System.Collections.Generic;
public enum SlimeStates
{
    IDLESTATE,
    MOVESTATE,
    DAMAGEDSTATE,
    APPROACHINGSTATE,
    ATTACKSTATE
} 

public class SlimeStateManager : StateManager<SlimeStates, SlimeContext>
{
    [SerializeField] DamageHandler damageHandler;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D col;
    [SerializeField] HealthManager health;
    [SerializeField] PlayerLocater locater;

    SlimeContext ctx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        ctx = new SlimeContext(gameObject, animator, rb, col, health, damageHandler, locater, Vector2.zero);

        states = new Dictionary<SlimeStates, AbstractState<SlimeStates, SlimeContext>>
        {
            { SlimeStates.IDLESTATE, new SlimeIdleState(ctx) },
            { SlimeStates.MOVESTATE, new SlimeMoveState(ctx) },
            { SlimeStates.DAMAGEDSTATE, new SlimeDamagedState(ctx) },
            { SlimeStates.ATTACKSTATE, new SlimeAttackState(ctx)}
        };

        Debug.Log("Why wont you work");
        currentState = states[SlimeStates.IDLESTATE];

        base.Start();
    }
}
