using System.Collections.Generic;
using UnityEngine;
using System;

/*public enum EnemyStates
{
    IDLESTATE,
    PURSUINGSTATE,
    DAMAGEDSTATE
}*/
/*
public abstract class EnemyStateManager<EStates, TContext> : StateManager<EnemyStates, EnemyContext> where EStates : Enum
{
    private EnemyContext ctx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created.
    void Start()
    {
        ctx = new EnemyContext();

        //states = new Dictionary<EStates, AbstractState<EStates, TContext>>();
    }

    protected void AddState(AbstractState<EnemyStates, EnemyContext> state)
    {
        states[state.StateKey] = state;
    }

    protected void RegisterSharedClasses()
    {
        AddState(new EnemyIdleState(ctx));
    }
}*/
