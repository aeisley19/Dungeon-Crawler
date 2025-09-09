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
    private ActionCooldown cooldown;
    private SharedPlayerContext sharedCtx;
    private PlayerAttackContext ctx;

    public void Start()
    {
        inputHandler = new KeyboardAttackInput();
        cooldown = gameObject.AddComponent<ActionCooldown>();
        sharedCtx = GetComponent<PlayerController>().SharedCtx;
        ctx = new PlayerAttackContext(gameObject, sharedCtx, inputHandler, cooldown);
        states = new Dictionary<PlayerActionStates, AbstractState<PlayerActionStates, PlayerAttackContext>>()
        {
            {PlayerActionStates.INACTIVESTATE, new PlayerInactiveState(ctx)},
            {PlayerActionStates.ATTACKSTATE, new PlayerAttackState(ctx)}
        };

        currentState = states[PlayerActionStates.INACTIVESTATE];
    }
}
