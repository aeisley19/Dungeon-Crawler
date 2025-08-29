using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerActionStates
{
    INACTIVESTATE,
    ATTACKSTATE
}
public class PlayerActionStateManager : StateManager<PlayerActionStates, PlayerAttackContext>
{
    private KeyboardAttackInput inputHandler;
    [SerializeField] private Animator animator; 
    private PlayerAttackContext ctx;

    public void Awake()
    {
        inputHandler = new KeyboardAttackInput();
        ctx = new PlayerAttackContext(inputHandler, animator);
        states = new Dictionary<PlayerActionStates, AbstractState<PlayerActionStates, PlayerAttackContext>>()
        {
            {PlayerActionStates.INACTIVESTATE, new PlayerInactiveState(ctx)},
            { PlayerActionStates.ATTACKSTATE, new PlayerAttackState(ctx)}
        };

        currentState = states[PlayerActionStates.INACTIVESTATE];
    }
}
