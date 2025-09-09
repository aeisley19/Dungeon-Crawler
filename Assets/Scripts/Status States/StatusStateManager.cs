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
    [SerializeField] private Collider2D col;
    private StatusContext ctx;

    public StatusStateManager()
    {
        ctx = new StatusContext(health, col);
        states = new Dictionary<StatusStates, AbstractState<StatusStates, StatusContext>>()
        {
            {StatusStates.UNDAMAGEDSTATE, new UndamagedState(ctx)}
        };

        currentState = states[StatusStates.UNDAMAGEDSTATE];
    }
}
