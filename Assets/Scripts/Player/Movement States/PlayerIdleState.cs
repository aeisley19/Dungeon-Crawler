using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerIdleState : AbstractState<PlayerStates, PlayerContext>
{
    public PlayerIdleState(PlayerContext ctx) : base(PlayerStates.IDLESTATE) => this.ctx = ctx;
    public override PlayerStates GetNextState()
    {
        if (ctx.InputHandler.GetAttackInput()) return PlayerStates.ATTACKSTATE;
        if (ctx.InputHandler.GetMovementInput() != Vector2.zero) return PlayerStates.WALKSTATE;

        return PlayerStates.IDLESTATE;
    }
}
