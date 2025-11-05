using UnityEngine;

public class SlimeDamagedState : AbstractState<SlimeStates, SlimeContext>
{
    private DamageEvent damageEvent;
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
        Debug.Log(ctx.DamageHandler.IsDamaged);
        if (!ctx.DamageHandler.IsDamaged)
        {
            return SlimeStates.IDLESTATE;
        }

        return SlimeStates.DAMAGEDSTATE;
    }
}
