using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerIdleState : AbstractState<PlayerMovementStates, PlayerMovementContext>
{
    public PlayerIdleState(PlayerMovementContext ctx) : base(PlayerMovementStates.IDLESTATE) => this.ctx = ctx;

    public override void EnterState()
    {
        ctx.Animator.SetBool("isMoving", false);
    }
    public override PlayerMovementStates GetNextState()
    {
        if (ctx.InputHandler.getMovementInput() != Vector2.zero) return PlayerMovementStates.WALKSTATE;

        return PlayerMovementStates.IDLESTATE;
    }
}
