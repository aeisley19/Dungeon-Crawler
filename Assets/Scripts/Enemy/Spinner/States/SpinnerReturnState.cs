using Unity.VisualScripting;
using UnityEngine;

public class SpinnerReturnState : AbstractState<SpinnerStates, SpinnerContext>
{
    public SpinnerReturnState(SpinnerContext ctx) : base(SpinnerStates.RETURNSTATE)
    {
        this.ctx = ctx;
    }

    public override void EnterState()
    {
        ctx.SetDirection(new Vector2(ctx.Direction.x * -1, ctx.Direction.y * -1));    
    }

    public override void UpdateState()
    {
        ctx.Rb.MovePosition(ctx.Rb.position + 5 * Time.deltaTime * ctx.Direction);
        Debug.Log("bleh " + Vector2.Distance(ctx.Rb.position, ctx.Origin));
    }

    public override void ExitState()
    {
        ctx.SetDirection(new Vector2(ctx.Direction.x * -1, ctx.Direction.y * -1));  
        ctx.Animator.SetBool("isAttacking", false);
    }

    public override SpinnerStates GetNextState()
    {
        if(Vector2.Distance(ctx.Origin, ctx.Rb.position) < 0.074f) return SpinnerStates.IDLESTATE;
        return SpinnerStates.RETURNSTATE;
    }
}
