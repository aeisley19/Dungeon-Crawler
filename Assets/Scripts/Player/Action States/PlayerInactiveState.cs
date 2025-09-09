using UnityEngine;

public class PlayerInactiveState : AbstractState<PlayerActionStates, PlayerAttackContext>
{
    public PlayerInactiveState(PlayerAttackContext ctx) : base(PlayerActionStates.INACTIVESTATE) => this.ctx = ctx;

    public override PlayerActionStates GetNextState()
    {
        if (ctx.InputHandler.AttackInput() && ctx.Cooldown.CooldownIsComplete()) return PlayerActionStates.ATTACKSTATE;

        return PlayerActionStates.INACTIVESTATE;
    }
}
