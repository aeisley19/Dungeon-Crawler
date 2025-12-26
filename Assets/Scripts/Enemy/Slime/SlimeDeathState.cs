using System;
using UnityEngine;

public class SlimeDeathState : AbstractState<SlimeStates, SlimeContext>, IAnimationListener
{
    private readonly AnimationEventHandler eventHandler;

    public SlimeDeathState(SlimeContext ctx) : base(SlimeStates.DEATHSTATE)
    {
        this.ctx = ctx;
        eventHandler = new AnimationEventHandler(ctx.Animator);
    }

    public override void EnterState()
    {
        eventHandler.Subscribe(this);
        ctx.Animator.SetBool("isDead", true);    
    }

    
    public override SlimeStates GetNextState()
    {
        return SlimeStates.DEATHSTATE;
    }

    public void OnAnimationEvent(string animationEvent)
    {
        if(animationEvent == "EndDeath")
        {
            eventHandler.UnSubscribe(this);
            UnityEngine.Object.Destroy(ctx.GameObject);
        }
    } 
}
