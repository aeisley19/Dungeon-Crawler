using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlimeAttackState : AbstractState<SlimeStates, SlimeContext>, IAnimationListener
{

    private readonly AnimationEventHandler eventHandler;
    private bool isAttacking;

    public SlimeAttackState(SlimeContext ctx) : base(SlimeStates.ATTACKSTATE)
    {
        this.ctx = ctx;
        eventHandler = new AnimationEventHandler(ctx.Animator);
    }

    public override void EnterState()
    {
        isAttacking = true;
        ctx.Animator.SetBool("isAttacking", isAttacking);
        eventHandler.Subscribe(this);
    }

    public void OnAnimationEvent(string animationEvent)
    {
        if (animationEvent == "AttackEnd") isAttacking = false;
        Debug.Log("is attacking is" + isAttacking);
    }
    
    public override void ExitState()
    {
        ctx.Animator.SetBool("isAttacking", isAttacking);
        eventHandler.UnSubscribe(this);   
    }

    public override SlimeStates GetNextState()
    {
        if (!isAttacking) return SlimeStates.IDLESTATE;
        return SlimeStates.ATTACKSTATE;
    }
}
