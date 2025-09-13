using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerStates
{
    IDLESTATE,
    WALKSTATE,
    ATTACKSTATE
}
public class PlayerStateManager : StateManager<PlayerStates, PlayerContext>
{
    [SerializeField] private float runSpd;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private KeyboardInput inputHandler;
    private SharedPlayerContext sharedCtx;
    private PlayerContext ctx;

    private void Start()
    {
        inputHandler = new KeyboardInput();
        ctx = new PlayerContext(gameObject, animator, runSpd, rb, inputHandler);

        states = new Dictionary<PlayerStates, AbstractState<PlayerStates, PlayerContext>>()
         {
             {PlayerStates.IDLESTATE, new PlayerIdleState(ctx)},
             {PlayerStates.WALKSTATE, new PlayerWalkState(ctx)},
             {PlayerStates.ATTACKSTATE, new PlayerAttackState(ctx)}
         };

        currentState = states[PlayerStates.IDLESTATE];
    }
}
