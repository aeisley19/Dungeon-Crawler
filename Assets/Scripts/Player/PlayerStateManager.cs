using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerStates
{
    IDLESTATE,
    WALKSTATE,
    ATTACKSTATE,
    DAMAGEDSTATE
}
public class PlayerStateManager : StateManager<PlayerStates, PlayerContext>
{
    [SerializeField] private float runSpd;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D col;
    [SerializeField] private Animator animator;
    [SerializeField] private HealthManager health;
    [SerializeField] private DamageHandler damageHandler;
    private KeyboardInput inputHandler;
    private PlayerContext ctx;

    private void Start()
    {
        inputHandler = new KeyboardInput();
        ctx = new PlayerContext(gameObject, animator, runSpd, rb, col, inputHandler, health, damageHandler);

        states = new Dictionary<PlayerStates, AbstractState<PlayerStates, PlayerContext>>()
         {
             {PlayerStates.IDLESTATE, new PlayerIdleState(ctx)},
             {PlayerStates.WALKSTATE, new PlayerWalkState(ctx)},
             {PlayerStates.ATTACKSTATE, new PlayerAttackState(ctx)},
             {PlayerStates.DAMAGEDSTATE, new PlayerDamagedState(ctx)}
         };

        currentState = states[PlayerStates.IDLESTATE];
    }
}
