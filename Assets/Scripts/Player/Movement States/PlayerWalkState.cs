using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerWalkState : AbstractState<PlayerMovementStates, PlayerMovementContext>
{
    private Vector2 input;
    private bool isMoving;
    private RotateHitBox rotateHitBox;
    private Transform hitBoxOrigin;
    private readonly PlayerMovement move;
    private readonly MovementAnimation moveAnim;

    public PlayerWalkState(PlayerMovementContext ctx) : base(PlayerMovementStates.WALKSTATE)
    {
        this.ctx = ctx;
        move = new PlayerMovement(this.ctx.Rb, this.ctx.RunSpd);
        moveAnim = new MovementAnimation(this.ctx.SharedCtx.Animator);
    }

    public override void EnterState()
    {
        input = ctx.InputHandler.GetMovementInput();
        hitBoxOrigin = ctx.GameObject.transform.Find("HitBoxOrigin");
        rotateHitBox = hitBoxOrigin.GetComponent<RotateHitBox>();
        isMoving = true;
        ctx.SharedCtx.Animator.SetBool("isMoving", isMoving);
    }
    public override void UpdateState()
    {
        move.Move(input);
        moveAnim.SetMovementDirection(input);
        input = ctx.InputHandler.GetMovementInput();
        ctx.SharedCtx.SetFacingDir(new Vector2(ctx.SharedCtx.Animator.GetFloat("moveX"), ctx.SharedCtx.Animator.GetFloat("moveY")));
        rotateHitBox.Rotate(new Vector2(ctx.SharedCtx.Animator.GetFloat("moveX"), ctx.SharedCtx.Animator.GetFloat("moveY")));
    }

    public override void ExitState()
    {
        isMoving = false;
        ctx.SharedCtx.Animator.SetBool("isMoving", isMoving);
    }

    public override PlayerMovementStates GetNextState()
    {
        if (input == Vector2.zero)
        {
            return PlayerMovementStates.IDLESTATE;
        }

        return PlayerMovementStates.WALKSTATE;
    }
}
