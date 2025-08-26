using System;
using UnityEngine;

public class PlayerAttackState : AbstractState<PlayerStates>, IAnimationListener
{

    private AnimationEventReceiver eventReceiver;
    private readonly AnimationEventHandler eventHandler;
    private bool isAttacking;

    public PlayerAttackState(PlayerContext ctx) : base(PlayerStates.attackState)
    {
        this.ctx = ctx;
        eventHandler = new AnimationEventHandler(ctx.Animator);
    }

    public override void EnterState()
    {
        isAttacking = true;
        eventReceiver = ctx.Animator.GetComponent<AnimationEventReceiver>();
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

    public override PlayerStates GetNextState()
    {
        Debug.Log(isAttacking);
        if (!isAttacking) return PlayerStates.IdleState;
        //else if(!isAttacking && ctx.IsMoving) return PlayerStates.WalkState;

        return PlayerStates.attackState;
    }
}
