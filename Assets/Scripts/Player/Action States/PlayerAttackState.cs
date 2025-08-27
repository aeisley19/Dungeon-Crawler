using System;
using UnityEngine;

public class PlayerAttackState : AbstractState<PlayerActionStates>, IAnimationListener
{

    private AnimationEventReceiver eventReceiver;
    private readonly AnimationEventHandler eventHandler;
    private bool isAttacking;

    public PlayerAttackState(PlayerContext ctx) : base(PlayerActionStates.ATTACKSTATE)
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

    public override PlayerActionStates GetNextState()
    {
        Debug.Log(isAttacking);
        //if (!isAttacking && ctx.InputHandler.getMovementInput() != Vector2.zero) return PlayerMovementStates.WALKSTATE;
        //else if(!isAttacking && ctx.InputHandler.getMovementInput() == Vector2.zero) return PlayerMovementStates.WALKSTATE;

        return PlayerActionStates.ATTACKSTATE;
    }
}
