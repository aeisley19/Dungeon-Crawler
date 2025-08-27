using System.Collections.Generic;
using UnityEngine;

public enum PlayerMovementStates
{
    IDLESTATE,
    WALKSTATE
}
    
public class PlayerStateManager : StateManager<PlayerMovementStates>
{
    [SerializeField] private float runSpd;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private KeyboardDirectionalInput inputHandler;
    private PlayerContext ctx;

    private void Awake()
    {
        inputHandler = new KeyboardDirectionalInput();
        ctx = new PlayerContext(runSpd, rb, animator, inputHandler);

        states = new Dictionary<PlayerMovementStates, AbstractState<PlayerMovementStates>>()
        {
            {PlayerMovementStates.IDLESTATE, new PlayerIdleState(ctx)},
            {PlayerMovementStates.WALKSTATE, new PlayerWalkState(ctx)}
            //{PlayerMovementStates.attackState, new PlayerAttackState(ctx)}

        };

        currentState = states[PlayerMovementStates.IDLESTATE];
    }

}
