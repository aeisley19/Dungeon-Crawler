using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerStates
{
    IDLESTATE,
    WALKSTATE,
    ATTACKSTATE,
    DAMAGEDSTATE,
    DEATHSTATE
}
public class PlayerStateManager : StateManager<PlayerStates, PlayerContext>
{
    [SerializeField] private float runSpd;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D col;
    [SerializeField] private Animator animator;
    [SerializeField] private HealthManager health;
    [SerializeField] private DamageHandler damageHandler;
    [SerializeField] private HealthUI ui;
    private KeyboardInput inputHandler;
    private PlayerContext ctx;

    protected override void Start()
    {
        inputHandler = new KeyboardInput();
        ctx = new PlayerContext(gameObject, animator, runSpd, rb, col, inputHandler, health, damageHandler, ui);

        states = new Dictionary<PlayerStates, AbstractState<PlayerStates, PlayerContext>>()
         {
             {PlayerStates.IDLESTATE, new PlayerIdleState(ctx)},
             {PlayerStates.WALKSTATE, new PlayerWalkState(ctx)},
             {PlayerStates.ATTACKSTATE, new PlayerAttackState(ctx)},
             {PlayerStates.DAMAGEDSTATE, new PlayerDamagedState(ctx)},
             {PlayerStates.DEATHSTATE, new PlayerDeathState(ctx)}
         };

        currentState = states[PlayerStates.IDLESTATE];

        base.Start();
    }
}
