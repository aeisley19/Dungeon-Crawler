using UnityEngine;

public class UndamagedState : AbstractState<StatusStates, StatusContext>, ICollidable
{
    public UndamagedState(StatusContext ctx) : base(StatusStates.UNDAMAGEDSTATE)
    {

    }

    public void OnTrigger(Collider2D other)
    {
        if (other.CompareTag("Enemy")) Debug.Log("I was hit");    
    }

    public override StatusStates GetNextState()
    {
        return StatusStates.UNDAMAGEDSTATE;
    }
}
