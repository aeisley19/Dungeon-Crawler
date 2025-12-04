using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerWalkState : AbstractState<PlayerStates, PlayerContext>
{
    private Vector2 input;
    private bool isMoving;
    private RotateHitBox rotateHitBox;
    private Transform hitBoxOrigin;
    private readonly PlayerMovement move;
    private readonly MovementAnimation moveAnim;

    public PlayerWalkState(PlayerContext ctx) : base(PlayerStates.WALKSTATE)
    {
        this.ctx = ctx;
        move = new PlayerMovement(this.ctx.Rb, this.ctx.RunSpd);
        moveAnim = new MovementAnimation(this.ctx.Animator);
    }

    public override void EnterState()
    {
        hitBoxOrigin = ctx.GameObject.transform.Find("HitBoxOrigin");
        rotateHitBox = hitBoxOrigin.GetComponent<RotateHitBox>();
        isMoving = true;
        ctx.Animator.SetBool("isMoving", isMoving);
    }
    public override void UpdateState()
    {
        move.Move(input);
        moveAnim.SetMovementDirection(input);
        input = ctx.InputHandler.GetMovementInput();
        rotateHitBox.Rotate(new Vector2(ctx.Animator.GetFloat("moveX"), ctx.Animator.GetFloat("moveY")));
    }

    public override void ExitState()
    {
        isMoving = false;
        ctx.Animator.SetBool("isMoving", isMoving);
    }

    public override PlayerStates GetNextState()
    {
        if (ctx.DamageHandler.IsTriggered) return PlayerStates.DAMAGEDSTATE;
        if (ctx.InputHandler.GetAttackInput()) return PlayerStates.ATTACKSTATE;
        if (ctx.InputHandler.GetMovementInput() == Vector2.zero) return PlayerStates.IDLESTATE;

        return PlayerStates.WALKSTATE;
    }
}
