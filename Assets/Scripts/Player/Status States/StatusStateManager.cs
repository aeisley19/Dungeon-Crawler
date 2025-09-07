using System.Collections.Generic;
using UnityEngine;


public enum StatusStates
{
    UNDAMAGEDSTATE,
    DAMAGEDSTATE,
    DEADSTATE
}

public class StatusStateManager : StateManager<StatusStates, StatusContext>
{
    [SerializeField] private float health; 
    private StatusContext ctx;

    public StatusStateManager()
    {
        ctx = new StatusContext(health);
        states = new Dictionary<StatusStates, AbstractState<StatusStates, StatusContext>>()
        {
            {StatusStates.UNDAMAGEDSTATE, new UndamagedState(ctx)}
        };
    }
}
