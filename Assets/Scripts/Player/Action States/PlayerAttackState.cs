using System;
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
        Debug.Log(ctx.SharedCtx.Animator.GetFloat("moveX") * Vector2.left + ctx.SharedCtx.Animator.GetFloat("moveY") * Vector2.down);
    }

    public override void UpdateState()
    {
        Debug.Log("attack " + ctx.SharedCtx.FacingDir);
        Debug.DrawLine(ctx.GameObject.transform.position, ctx.GameObject.transform.position + ctx.SharedCtx.FacingDir, Color.red, 10f);
    }
        
    

    //May need to optomize later.
    public void OnAnimationEvent(String animationEvent)
    {
        if (animationEvent == "endattack") isAttacking = false;
    }

    public override void ExitState()
    {
        ctx.SharedCtx.Animator.SetBool("isAttacking", false);
        eventHandler.UnSubscribe(this);
    }

    public override PlayerActionStates GetNextState()
    {
        if (!isAttacking) return PlayerActionStates.INACTIVESTATE;

        return PlayerActionStates.ATTACKSTATE;
    }
}
