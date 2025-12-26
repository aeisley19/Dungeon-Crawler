using UnityEngine;

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

    public override void UpdateState()
    {
        ctx.Rb.MovePosition(ctx.Rb.position + 5 * Time.deltaTime * ctx.MoveTowards);
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
        ctx.MoveTowards = Vector2.zero;
    }

    public override SlimeStates GetNextState()
    {
        if (ctx.Health.Hearts <= 0) return SlimeStates.DEATHSTATE;
        if (!isAttacking) return SlimeStates.IDLESTATE;
        if (ctx.DamageHandler.IsTriggered) return SlimeStates.DAMAGEDSTATE;
        return SlimeStates.ATTACKSTATE;
    }
}
