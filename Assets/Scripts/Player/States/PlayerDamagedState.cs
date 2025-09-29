using System;
using UnityEngine;

public class PlayerDamagedState : AbstractState<PlayerStates, PlayerContext>, IAnimationListener
{
    private readonly AnimationEventHandler eventHandler;
    private readonly KnockbackHandler knockback;
    private readonly IFramesHandler iFrames;

    public PlayerDamagedState(PlayerContext ctx) : base(PlayerStates.DAMAGEDSTATE)
    {
        this.ctx = ctx;

        knockback = new KnockbackHandler(ctx.Rb);
        eventHandler = new AnimationEventHandler(ctx.Animator);
        iFrames = new IFramesHandler(ctx.Col);
    }

    public override void EnterState()
    {
        eventHandler.Subscribe(this);
        ctx.Animator.SetBool("isDamaged", ctx.DamageHandler.IsDamaged);
        knockback.Knockback(ctx.DamageHandler.Other);
        CoroutineCaller.Instance.Run(iFrames.InitializeIFrames());
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

    public override PlayerStates GetNextState()
    {
        if (!ctx.DamageHandler.IsDamaged) return PlayerStates.IDLESTATE;

        return PlayerStates.DAMAGEDSTATE;
    }
}
