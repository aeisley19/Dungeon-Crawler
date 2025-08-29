using System;
using UnityEngine;

public class PlayerAttackState : AbstractState<PlayerActionStates, PlayerAttackContext>, IAnimationListener
{
    private readonly AnimationEventHandler eventHandler;
    private bool isAttacking;

    public PlayerAttackState(PlayerAttackContext ctx) : base(PlayerActionStates.ATTACKSTATE)
    {
        this.ctx = ctx;
        eventHandler = new AnimationEventHandler(ctx.Animator);
    }

    public override void EnterState()
    {
        isAttacking = true;
        ctx.Animator.SetBool("isAttacking", true);
        eventHandler.Subscribe(this);
    }

    //May need to optomize later.
    public void OnAnimationEvent(String animationEvent)
    {
        if (animationEvent == "endattack") isAttacking = false;
    }

    public override void ExitState()
    {
        ctx.Animator.SetBool("isAttacking", false);
        eventHandler.UnSubscribe(this);
    }

    public override PlayerActionStates GetNextState()
    {
        Debug.Log(isAttacking);
        if (!isAttacking) return PlayerActionStates.INACTIVESTATE;

        return PlayerActionStates.ATTACKSTATE;
    }
}
