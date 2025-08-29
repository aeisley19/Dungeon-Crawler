using UnityEngine;

public class PlayerInactiveState : AbstractState<PlayerActionStates, PlayerAttackContext>
{
    public PlayerInactiveState(PlayerAttackContext ctx) : base(PlayerActionStates.INACTIVESTATE) => this.ctx = ctx;

    public override PlayerActionStates GetNextState()
    {
        Debug.Log(ctx.InputHandler.AttackInput());
        if (ctx.InputHandler.AttackInput()) return PlayerActionStates.ATTACKSTATE;

        return PlayerActionStates.INACTIVESTATE;
    }
}
