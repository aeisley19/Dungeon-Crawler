using UnityEngine;

public class UndamagedState : AbstractState<StatusStates, StatusContext>
{
    public UndamagedState(StatusContext ctx) : base(StatusStates.UNDAMAGEDSTATE)
    {
        
    }

    public override StatusStates GetNextState()
    {
        return StatusStates.UNDAMAGEDSTATE;
    }
}
