using UnityEngine;

public class SlimeDamagedState : AbstractState<SlimeStates, SlimeContext>
{
    private readonly DamageEvent damageEvent;
    public SlimeDamagedState(SlimeContext ctx) : base(SlimeStates.DAMAGEDSTATE)
    {
        this.ctx = ctx;
        damageEvent = new(ctx.DamageHandler, ctx.Health, ctx.Animator, ctx.Rb);
    }

    public override void EnterState()
    {
        damageEvent.EnterHandler();
    }

    public override void ExitState()
    {
        damageEvent.ExitHandler();
    }

    public override SlimeStates GetNextState()
    {

        if (!ctx.DamageHandler.IsTriggered)
        {
            return SlimeStates.IDLESTATE;
        }

        return SlimeStates.DAMAGEDSTATE;
    }
}
