using Unity.VisualScripting;
using UnityEngine;

public class SpinnerAttackState : AbstractState<SpinnerStates, SpinnerContext>, ICollidable
{
    private bool hitWall = false;

    public SpinnerAttackState(SpinnerContext ctx) : base(SpinnerStates.ATTACKSTATE)
    {
        this.ctx = ctx;    
    }

    public override void EnterState()
    {
        ctx.Animator.SetBool("isAttacking", true);
    }

    public override void ExitState()
    {
        hitWall = false;
    }
    public override void UpdateState()
    {
        ctx.Rb.MovePosition(ctx.Rb.position + 5 * Time.deltaTime * ctx.Direction);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Spinner") hitWall = true;
    }

    public override SpinnerStates GetNextState()
    {
        if(hitWall) return SpinnerStates.RETURNSTATE;
        return SpinnerStates.ATTACKSTATE;
    }
}
