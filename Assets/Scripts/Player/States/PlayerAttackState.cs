using UnityEngine;

public class PlayerAttackState : AbstractState<PlayerStates>
{
    private AnimationEventReceiver eventReceiver;
    private bool isAttacking;

    public PlayerAttackState(PlayerContext ctx) : base(PlayerStates.attackState)
    {
        this.ctx = ctx;
    }

    public override void EnterState()
    {
        isAttacking = true;
        eventReceiver = ctx.Animator.GetComponent<AnimationEventReceiver>();
        ctx.Animator.SetBool("isAttacking", true);
        eventReceiver.OnAnimationEnded += HandleAnimationEnd;
    }

    public override void UpdateState()
    {
        //ctx.Animator.SetBool("isAttacking", true);
    }

    private void HandleAnimationEnd(AnimationEvent animationEvent) => isAttacking = false; 

    public override void ExitState()
    {
        ctx.Animator.SetBool("isAttacking", false);
    }

    public override PlayerStates GetNextState()
    {
        Debug.Log(isAttacking);
        if (!isAttacking) return PlayerStates.IdleState;
        //else if(!isAttacking && ctx.IsMoving) return PlayerStates.WalkState;

        return PlayerStates.attackState;
    }
}
