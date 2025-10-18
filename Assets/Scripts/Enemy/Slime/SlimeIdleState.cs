using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class SlimeIdleState : AbstractState<SlimeStates, SlimeContext>
{
    public SlimeIdleState(SlimeContext ctx) : base(SlimeStates.IDLESTATE) => this.ctx = ctx;
    public override SlimeStates GetNextState()
    {
        if (ctx.DamageHandler.IsDamaged) return SlimeStates.DAMAGEDSTATE;
        return SlimeStates.IDLESTATE;
    }
}
