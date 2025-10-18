using System;
using NUnit.Framework;
using UnityEngine;

public abstract class AbstractDamagedState<EState, TContext> : AbstractState<EState, TContext>, IAnimationListener
    where EState : Enum where TContext : SharedAliveObjectsContext
{
    private readonly AnimationEventHandler eventHandler;
    private readonly KnockbackHandler knockback;

    public AbstractDamagedState(EState state, TContext ctx) : base(state)
    {
        this.ctx = ctx;
        knockback = new KnockbackHandler(ctx.Rb);
        eventHandler = new AnimationEventHandler(ctx.Animator);
    }

    public override void EnterState()
    {
        eventHandler.Subscribe(this);
        ctx.Animator.SetBool("isDamaged", ctx.DamageHandler.IsDamaged);
        knockback.Knockback(ctx.DamageHandler.Other, 10);
        ctx.Health.LoseHealth(0.5f); //Change later. You need dynamic damage. 
    }

    public override void ExitState()
    {
 
        eventHandler.UnSubscribe(this);
        ctx.Animator.SetBool("isDamaged", ctx.DamageHandler.IsDamaged);
        ctx.Rb.linearVelocity = Vector2.zero;
        
    }

    public void OnAnimationEvent(string animationEvent)
    {
        
        if (animationEvent == "EndDamage") ctx.DamageHandler.SetIsDamaged(false);
    }
}
