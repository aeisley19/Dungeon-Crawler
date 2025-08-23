using UnityEngine;

public class PlayerAttackState : AbstractState<PlayerStates>
{
    public PlayerAttackState() : base(PlayerStates.attackState)
    {
        
    }
    
    public override void EnterState()
    {

    }

    public override void UpdateState()
    {

    }
    public override void ExitState()
    {
    }

    public override PlayerStates GetNextState()
    {
        //replace
        return PlayerStates.IdleState;
    }
}
