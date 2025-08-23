using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerIdleState : AbstractState<PlayerStates>
{
    //private Vector3 input;

    public PlayerIdleState(PlayerContext ctx) : base(PlayerStates.IdleState)
    {
        this.ctx = ctx;
    }

    public override void UpdateState()
    {
        //ctx.Input = ctx.InputHandler.getMovementInput();
        //Debug.Log(input);
    }

    public override void ExitState()
    {
        //ctx.Animator.SetBool("isMoving", false);
    }

    public override PlayerStates GetNextState()
    {
        if (ctx.InputHandler.getMovementInput() != Vector2.zero)
        {
            return PlayerStates.WalkState;
        }

        return PlayerStates.IdleState;
    }
}
