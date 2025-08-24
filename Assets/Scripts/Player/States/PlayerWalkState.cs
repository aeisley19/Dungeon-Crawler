using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerWalkState : AbstractState<PlayerStates>
{
    private Vector2 input;
    private bool isMoving;
    private readonly PlayerMovement move;
    private readonly MovementAnimation moveAnim;

    public PlayerWalkState(PlayerContext ctx) : base(PlayerStates.WalkState)
    {
        this.ctx = ctx;
        move = new PlayerMovement(this.ctx.Rb, this.ctx.RunSpd);
        moveAnim = new MovementAnimation(this.ctx.Animator);
    }

    public override void EnterState()
    {
        input = ctx.InputHandler.getMovementInput();
        isMoving = true;
        ctx.Animator.SetBool("isMoving", isMoving);

    }

    public override void UpdateState()
    {
        move.Move(input);
        moveAnim.SetMovementDirection(input);
        input = ctx.InputHandler.getMovementInput();
    }

    public override void ExitState()
    {
        isMoving = false;
        ctx.Animator.SetBool("isMoving", isMoving);
    }

    public override PlayerStates GetNextState()
    {
        if (input == Vector2.zero)
        {
            return PlayerStates.IdleState;
        }

        if (ctx.InputHandler.AttackInput()) return PlayerStates.attackState;

        return PlayerStates.WalkState;
    }
}
