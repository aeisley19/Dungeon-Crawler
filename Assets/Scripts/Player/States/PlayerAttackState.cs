using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackState : AbstractState<PlayerStates, PlayerContext>, IAnimationListener
{
    private readonly AnimationEventHandler eventHandler;
    private bool isAttacking;

    public PlayerAttackState(PlayerContext ctx) : base(PlayerStates.ATTACKSTATE)
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
    public void OnAnimationEvent(string animationEvent)
    {
        if (animationEvent == "EndAttack") isAttacking = false;
    }

    public override void ExitState()
    {
        ctx.Animator.SetBool("isAttacking", false);
        eventHandler.UnSubscribe(this);
    }

    public override PlayerStates GetNextState()
    {
        //if (ctx.DamageHandler.IsDamaged) return PlayerStates.DAMAGEDSTATE;
        if (!isAttacking) return PlayerStates.IDLESTATE;

        return PlayerStates.ATTACKSTATE;
    }
}
