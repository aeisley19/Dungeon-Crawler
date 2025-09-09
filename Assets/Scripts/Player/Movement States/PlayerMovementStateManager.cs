using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerMovementStates
{
    IDLESTATE,
    WALKSTATE
}

[RequireComponent(typeof(PlayerController))]
public class PlayerMovementStateManager : StateManager<PlayerMovementStates, PlayerMovementContext>
{
    [SerializeField] private float runSpd;
    [SerializeField] private Rigidbody2D rb;
    private KeyboardDirectionalInput inputHandler;
    private SharedPlayerContext sharedCtx;
    private PlayerMovementContext ctx;

    private void Start()
    {
        inputHandler = new KeyboardDirectionalInput();
        sharedCtx = GetComponent<PlayerController>().SharedCtx;
        ctx = new PlayerMovementContext(gameObject, sharedCtx, runSpd, rb, inputHandler);

        states = new Dictionary<PlayerMovementStates, AbstractState<PlayerMovementStates, PlayerMovementContext>>()
         {
             {PlayerMovementStates.IDLESTATE, new PlayerIdleState(ctx)},
             {PlayerMovementStates.WALKSTATE, new PlayerWalkState(ctx)}
         };

        currentState = states[PlayerMovementStates.IDLESTATE];
    }
}
