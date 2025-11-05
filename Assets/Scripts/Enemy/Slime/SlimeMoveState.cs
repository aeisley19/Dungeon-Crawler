using UnityEngine;

public class SlimeMoveState : AbstractState<SlimeStates, SlimeContext>
{
    private Vector2 dir;
    private RaycastHit2D hitWall;
    private Vector2 startPos;

    public SlimeMoveState(SlimeContext ctx) : base(SlimeStates.MOVESTATE)
    {
        this.ctx = ctx;
        startPos = ctx.Rb.position; 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public override void EnterState()
    {
        startPos = ctx.Rb.position;   
    }
    
    public override void UpdateState()
    {
        ctx.Rb.MovePosition(ctx.Rb.position + 2 * Time.deltaTime * ctx.MoveTowards);
    }

    public override void ExitState()
    {
        ctx.MoveTowards = Vector2.zero;
    }
    
    public override SlimeStates GetNextState()
    {
        if (ctx.Rb.position == startPos + ctx.MoveTowards) return SlimeStates.IDLESTATE;
        if (ctx.DamageHandler.IsDamaged) return SlimeStates.DAMAGEDSTATE;
        return SlimeStates.MOVESTATE;
    }
}
