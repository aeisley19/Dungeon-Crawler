using System.Collections.Generic;
using UnityEngine;

public enum PlayerMovementStates
{
    IDLESTATE,
    WALKSTATE
}
    
public class PlayerMovementStateManager : StateManager<PlayerMovementStates, PlayerMovementContext>
{
    [SerializeField] private float runSpd;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private KeyboardDirectionalInput inputHandler;
    private PlayerMovementContext ctx;
    
    private void Awake()
    {
        inputHandler = new KeyboardDirectionalInput();
        ctx = new PlayerMovementContext(runSpd, rb, animator, inputHandler);

        states = new Dictionary<PlayerMovementStates, AbstractState<PlayerMovementStates, PlayerMovementContext>>()
        {
            {PlayerMovementStates.IDLESTATE, new PlayerIdleState(ctx)},
            {PlayerMovementStates.WALKSTATE, new PlayerWalkState(ctx)}
        };

        currentState = states[PlayerMovementStates.IDLESTATE];
    }

}
