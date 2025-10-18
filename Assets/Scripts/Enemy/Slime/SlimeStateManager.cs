using UnityEngine;
using System.Collections.Generic;
public enum SlimeStates
{
    IDLESTATE,
    DAMAGEDSTATE
} 

public class SlimeStateManager : StateManager<SlimeStates, SlimeContext>
{
    [SerializeField] DamageHandler damageHandler;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D col;
    [SerializeField] HealthManager health;

    SlimeContext ctx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("slime");
        ctx = new SlimeContext(gameObject, animator, rb, col, health, damageHandler);

        states = new Dictionary<SlimeStates, AbstractState<SlimeStates, SlimeContext>>
        {
            { SlimeStates.IDLESTATE, new SlimeIdleState(ctx) },
            { SlimeStates.DAMAGEDSTATE, new SlimeDamagedState(ctx) }
        };

        currentState = states[SlimeStates.IDLESTATE];
    }
}
