using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates
{
    IDLESTATE,
    DAMAGEDSTATE
}


public class EnemyStateManager : StateManager<EnemyStates, EnemyContext>
{

    private EnemyContext ctx;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ctx = new EnemyContext();

        states = new Dictionary<EnemyStates, AbstractState<EnemyStates, EnemyContext>>()
        {
            //{EnemyStates.IDLESTATE, new EnemyIdleState(ctx)}
        };
    }
}
