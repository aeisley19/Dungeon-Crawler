using UnityEngine;

public class SlimePrepareToAttackState : AbstractState<SlimeStates, SlimeContext>
{
    private const float TIMEREND = 1f;
    private float timer;
    
    public SlimePrepareToAttackState(SlimeContext ctx) : base(SlimeStates.PREPARETOATTACKSTATE)
    {
        this.ctx = ctx;
    }

    public override void EnterState()
    {
        timer = 0f;
        ctx.Animator.speed += 5;
    }

    public override void UpdateState()
    {
        timer += Time.deltaTime;
    }

    public override void ExitState()
    {
        ctx.Animator.speed -= 5;
        ctx.MoveTowards = ctx.FindPlayer.GetDirection();
    }

    public override SlimeStates GetNextState()
    {
        if(ctx.Health.Hearts <= 0)
        {
            ctx.Animator.SetBool("isDamaged", false);
            Debug.Log("Fuck " + ctx.Animator.GetBool("isDamaged"));
            return SlimeStates.DEATHSTATE;
        }
        
        if (timer >= TIMEREND) return SlimeStates.ATTACKSTATE;
        if (ctx.DamageHandler.IsTriggered) return SlimeStates.DAMAGEDSTATE;
        return SlimeStates.PREPARETOATTACKSTATE;
    }
}
