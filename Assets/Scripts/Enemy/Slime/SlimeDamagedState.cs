using UnityEngine;

public class SlimeDamagedState : AbstractDamagedState<SlimeStates, SlimeContext>
{
    public SlimeDamagedState(SlimeContext ctx) : base(SlimeStates.DAMAGEDSTATE, ctx) => this.ctx = ctx;

    public override SlimeStates GetNextState()
    {
        Debug.Log(ctx.DamageHandler.IsDamaged);
        if (!ctx.DamageHandler.IsDamaged)
        {
            Debug.Log("why am i not here");
           return SlimeStates.IDLESTATE; 
        }
        Debug.Log("fail");
        return SlimeStates.DAMAGEDSTATE;
    }
}
