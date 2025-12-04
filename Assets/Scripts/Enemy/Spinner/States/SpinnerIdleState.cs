using UnityEngine;

public class SpinnerIdleState : AbstractState<SpinnerStates, SpinnerContext>
{
 //   private bool isTriggered;

    public SpinnerIdleState(SpinnerContext ctx) : base(SpinnerStates.IDLESTATE)
    {
        this.ctx = ctx;
    }

    public override void EnterState()
    {
        ctx.GameObject.GetComponentInParent<Collider2D>().enabled = true;
    }

    public override SpinnerStates GetNextState()
    {
        if(ctx.SpinnerTrigger.IsTriggered) return SpinnerStates.ATTACKSTATE;
        return SpinnerStates.IDLESTATE;
    }
}
