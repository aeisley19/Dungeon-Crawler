using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerActionStates
{
    INACTIVESTATE,
    ATTACKSTATE
}

[RequireComponent(typeof(PlayerController))]
public class PlayerActionStateManager : StateManager<PlayerActionStates, PlayerAttackContext>
{
    private KeyboardAttackInput inputHandler;
    private SharedPlayerContext sharedCtx;
    private PlayerAttackContext ctx;

    public void Awake()
    {
        inputHandler = new KeyboardAttackInput();
        sharedCtx = GetComponent<PlayerController>().SharedCtx;
        ctx = new PlayerAttackContext(gameObject, sharedCtx, inputHandler);
        states = new Dictionary<PlayerActionStates, AbstractState<PlayerActionStates, PlayerAttackContext>>()
        {
            {PlayerActionStates.INACTIVESTATE, new PlayerInactiveState(ctx)},
            { PlayerActionStates.ATTACKSTATE, new PlayerAttackState(ctx)}
        };

        currentState = states[PlayerActionStates.INACTIVESTATE];
    }
}
