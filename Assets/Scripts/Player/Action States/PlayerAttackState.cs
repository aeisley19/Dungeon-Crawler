using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackState : AbstractState<PlayerActionStates, PlayerAttackContext>, IAnimationListener
{
    private readonly AnimationEventHandler eventHandler;
    private bool isAttacking;

    public PlayerAttackState(PlayerAttackContext ctx) : base(PlayerActionStates.ATTACKSTATE)
    {
        this.ctx = ctx;
        eventHandler = new AnimationEventHandler(ctx.SharedCtx.Animator);
    }

    public override void EnterState()
    {
        isAttacking = true;
        ctx.SharedCtx.Animator.SetBool("isAttacking", true);
        eventHandler.Subscribe(this);
    }

    public override void UpdateState()
    {
        Debug.Log("attacking");
    }

    //May need to optomize later.
    public void OnAnimationEvent(string animationEvent)
    {
        if (animationEvent == "endattack") isAttacking = false;
    }

    public override void ExitState()
    {
        ctx.SharedCtx.Animator.SetBool("isAttacking", false);
        eventHandler.UnSubscribe(this);
        ctx.Cooldown.InitiateCooldown(0.25f);
    }

    public override PlayerActionStates GetNextState()
    {
        if (!isAttacking) return PlayerActionStates.INACTIVESTATE;

        return PlayerActionStates.ATTACKSTATE;
    }
}
