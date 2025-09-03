using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerIdleState : AbstractState<PlayerMovementStates, PlayerMovementContext>
{
    public PlayerIdleState(PlayerMovementContext ctx) : base(PlayerMovementStates.IDLESTATE) => this.ctx = ctx;

    public override void EnterState()
    {
        ctx.SharedCtx.Animator.SetBool("isMoving", false);
        Debug.Log("idle " + ctx.SharedCtx.FacingDir);
    }
    public override PlayerMovementStates GetNextState()
    {
        if (ctx.InputHandler.GetMovementInput() != Vector2.zero) return PlayerMovementStates.WALKSTATE;

        return PlayerMovementStates.IDLESTATE;
    }
}
