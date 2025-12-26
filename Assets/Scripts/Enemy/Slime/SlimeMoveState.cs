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

    public override void EnterState()
    {
        startPos = ctx.Rb.position;
    }
    
    public override void UpdateState()
    {
        ctx.Rb.MovePosition(ctx.Rb.position + 1 * Time.deltaTime * ctx.MoveTowards);
    }

    public override void ExitState()
    {
        ctx.MoveTowards = Vector2.zero;
    }
    
    public override SlimeStates GetNextState()
    {
        if(ctx.Health.Hearts <= 0)
        {
            ctx.Animator.SetBool("isDamaged", false);
            Debug.Log("Fuck " + ctx.Animator.GetBool("isDamaged"));
            return SlimeStates.DEATHSTATE;
        }
        
        if (Vector2.Distance(ctx.Rb.position, startPos + ctx.MoveTowards) < 0.01f) return SlimeStates.IDLESTATE;
        if (ctx.Detector.Detect(ctx.GameObject, ctx.AttackRadius)) return SlimeStates.PREPARETOATTACKSTATE;
        if (ctx.DamageHandler.IsTriggered) return SlimeStates.DAMAGEDSTATE;
        return SlimeStates.MOVESTATE;
    }
}