using UnityEngine;

public class SlimeApproachingState : AbstractState<SlimeStates, SlimeContext>
{
    public SlimeApproachingState(SlimeContext ctx) : base(SlimeStates.APPROACHINGSTATE)
    {
        this.ctx = ctx;
    }

    public override void UpdateState()
    {
        ctx.MoveTowards = ctx.FindPlayer.GetDirection();
        ctx.Rb.MovePosition(ctx.Rb.position + 1 * Time.deltaTime * ctx.MoveTowards);
    }

    public override SlimeStates GetNextState()
    {
        throw new System.NotImplementedException();
    }
}