using System.Collections.Generic;
using UnityEngine;

public enum PlayerStates
{
    IdleState,
    WalkState,
    attackState
}
    
public class PlayerStateManager : StateManager<PlayerStates>
{
    [SerializeField] private float runSpd;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private KeyboardInput inputHandler;
    private Vector2 input;

    PlayerContext ctx;

    private void Awake()
    {
        inputHandler = new KeyboardInput();
        ctx = new PlayerContext(runSpd, rb, animator, inputHandler);

        states = new Dictionary<PlayerStates, AbstractState<PlayerStates>>()
        {
            {PlayerStates.IdleState, new PlayerIdleState(ctx)},
            {PlayerStates.WalkState, new PlayerWalkState(ctx)},
            {PlayerStates.attackState, new PlayerAttackState()}

        };

        currentState = states[PlayerStates.IdleState];
    }

}
