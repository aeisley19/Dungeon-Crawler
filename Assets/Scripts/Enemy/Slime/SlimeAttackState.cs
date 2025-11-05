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
        ctx.MoveTowards = -(ctx.GameObject.transform.position - GameObject.Find("Player").transform.position);
        eventHandler.Subscribe(this);
    }

    public override void UpdateState()
    {
        Debug.Log("position " + ctx.MoveTowards);
        ctx.Rb.MovePosition(ctx.Rb.position + 1 * Time.deltaTime * ctx.MoveTowards);
    }

    public void OnAnimationEvent(string animationEvent)
    {
        if (animationEvent == "AttackEnd") isAttacking = false;
    }
    
    public override void ExitState()
    {
        isAttacking = false;
        ctx.Animator.SetBool("isAttacking", isAttacking);
        eventHandler.UnSubscribe(this);   
    }

    public override SlimeStates GetNextState()
    {
        if (!isAttacking) return SlimeStates.IDLESTATE;
        if (ctx.DamageHandler.IsDamaged) return SlimeStates.DAMAGEDSTATE;
        return SlimeStates.ATTACKSTATE;
    }
}
