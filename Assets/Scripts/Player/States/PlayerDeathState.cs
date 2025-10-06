using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDeathState : AbstractState<PlayerStates, PlayerContext>
{
    public PlayerDeathState(PlayerContext ctx) : base(PlayerStates.DEATHSTATE)
    {
        this.ctx = ctx;
    }

    public override void EnterState()
    {
        Debug.Log("i am dead");
        ctx.Animator.SetBool("isDead", true);
        Debug.Log("is dead " + ctx.Animator.GetBool("isDead"));
    }

    public override PlayerStates GetNextState()
    {
        return PlayerStates.DEATHSTATE;
    }
}
