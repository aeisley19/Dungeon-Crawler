using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerIdleState : AbstractState<PlayerMovementStates, PlayerMovementContext>
{
    public PlayerIdleState(PlayerMovementContext ctx) : base(PlayerMovementStates.IDLESTATE) => this.ctx = ctx;
    public override PlayerMovementStates GetNextState()
    {
        Debug.Log(ctx.InputHandler.GetMovementInput());
        if (ctx.InputHandler.GetMovementInput() != Vector2.zero) return PlayerMovementStates.WALKSTATE;

        return PlayerMovementStates.IDLESTATE;
    }
}
