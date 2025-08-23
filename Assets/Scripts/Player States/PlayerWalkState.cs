using UnityEngine;

public class PlayerWalkState : AbstractState<PlayerStates>
{
    bool isMoving;
    private PlayerMovement move;

    public PlayerWalkState(PlayerContext ctx) : base(PlayerStates.WalkState)
    {
        this.ctx = ctx;
        move = new PlayerMovement(this.ctx.Rb, this.ctx.RunSpd);
    }

    public override void EnterState()
    {
        isMoving = true;
    }

    public override void UpdateState()
    {
        //Debug.Log("walk");
        //Debug.Log(ctx.InputHandler.getMovementInput());
        //input = ctx.InputHandler.getMovem"entInput();
        move.Move(ctx.InputHandler.getMovementInput());
    }

    public override void ExitState()
    {
        isMoving = false;
    }

    public override PlayerStates GetNextState()
    {
        if (ctx.InputHandler.getMovementInput() == Vector2.zero)
        {
            return PlayerStates.IdleState;
        }

        return PlayerStates.WalkState;
    }
}
