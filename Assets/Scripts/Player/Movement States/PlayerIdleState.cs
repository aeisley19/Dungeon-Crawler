using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerIdleState : AbstractState<PlayerMovementStates>
{
    //private Vector3 input;

    public PlayerIdleState(PlayerContext ctx) : base(PlayerMovementStates.IDLESTATE) => this.ctx = ctx;

    public override PlayerMovementStates GetNextState()
    {
        if (ctx.InputHandler.getMovementInput() != Vector2.zero) return PlayerMovementStates.WALKSTATE;

        return PlayerMovementStates.IDLESTATE;
    }
}
