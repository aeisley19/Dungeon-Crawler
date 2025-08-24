using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerIdleState : AbstractState<PlayerStates>
{
    //private Vector3 input;

    public PlayerIdleState(PlayerContext ctx) : base(PlayerStates.IdleState) => this.ctx = ctx;

    public override PlayerStates GetNextState()
    {
        if (ctx.InputHandler.getMovementInput() != Vector2.zero) return PlayerStates.WalkState;

        if (ctx.InputHandler.AttackInput()) return PlayerStates.attackState;

        return PlayerStates.IdleState;
    }
}
