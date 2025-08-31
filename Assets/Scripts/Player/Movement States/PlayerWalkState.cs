using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerWalkState : AbstractState<PlayerMovementStates, PlayerMovementContext>
{
    private Vector2 input;
    private bool isMoving;
    private RotateHitBox rotateHitBox;
    private readonly PlayerMovement move;
    private readonly MovementAnimation moveAnim;

    public PlayerWalkState(PlayerMovementContext ctx) : base(PlayerMovementStates.WALKSTATE)
    {
        this.ctx = ctx;
        move = new PlayerMovement(this.ctx.Rb, this.ctx.RunSpd);
        moveAnim = new MovementAnimation(this.ctx.Animator);
    }

    public override void EnterState()
    {
        input = ctx.InputHandler.GetMovementInput();
        rotateHitBox = ctx.GameObject.transform.Find("HitBoxOrigin").GetComponent<RotateHitBox>();
        isMoving = true;
        ctx.Animator.SetBool("isMoving", isMoving);
    }

    public override void UpdateState()
    {
        move.Move(input);
        moveAnim.SetMovementDirection(input);
        input = ctx.InputHandler.GetMovementInput();
        Debug.Log(ctx.GameObject.name);
        rotateHitBox.Rotate(new Vector2(ctx.Animator.GetFloat("moveX"), ctx.Animator.GetFloat("moveY")));
    }

    public override void ExitState()
    {
        isMoving = false;
        ctx.Animator.SetBool("isMoving", isMoving);
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
