using UnityEngine;

public class SlimeMoveState : AbstractState<SlimeStates, SlimeContext>
{
    private Vector2 dir;

    public SlimeMoveState(SlimeContext ctx) : base(SlimeStates.MOVESTATE) => this.ctx = ctx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public override void EnterState()
    {
        Debug.Log("movish");
    }
    
    public override void UpdateState()
    {

    }

    public override SlimeStates GetNextState()
    {
        return SlimeStates.MOVESTATE;
    }
}
