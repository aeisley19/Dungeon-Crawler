using UnityEngine;

public class PlayerInactiveState : AbstractState<PlayerActionStates, PlayerAttackContext>
{
    private float cooldown;

    public PlayerInactiveState(PlayerAttackContext ctx) : base(PlayerActionStates.INACTIVESTATE) => this.ctx = ctx;


    public override void UpdateState()
    {
        Debug.Log("Inactive");
    }
    public override PlayerActionStates GetNextState()
    {
        if (ctx.InputHandler.AttackInput() && ctx.Cooldown.CooldownIsComplete()) return PlayerActionStates.ATTACKSTATE;

        return PlayerActionStates.INACTIVESTATE;
    }
}
