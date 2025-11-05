using UnityEngine;

public class SlimeApproachingState : AbstractState<SlimeStates, SlimeContext>
{
    public SlimeApproachingState(SlimeContext ctx) : base(SlimeStates.APPROACHINGSTATE)
    {
        this.ctx = ctx;
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
    public override SlimeStates GetNextState()
    {
        throw new System.NotImplementedException();
    }
}
