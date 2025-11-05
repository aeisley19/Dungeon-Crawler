using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class StateManager<EState, TContext> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, AbstractState<EState, TContext>> states;
    protected AbstractState<EState, TContext> currentState;
    protected bool isTransitioningStates = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Debug.Log("fuckyou " + currentState);
        currentState?.EnterState();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        print(currentState);
        EState nextStateKey = currentState.GetNextState();

        if (nextStateKey.Equals(currentState.StateKey)) currentState.UpdateState();
        else if (!isTransitioningStates) TransitionToState(nextStateKey);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (currentState is ICollidable collidableState)
        {
            collidableState.OnTrigger(col);
        }
    }

    public void TransitionToState(EState stateKey)
    {
        Debug.Log("fuckme " + currentState);
        isTransitioningStates = true;
        currentState.ExitState();
        currentState = states[stateKey];
        currentState.EnterState();
        isTransitioningStates = false;
    }
}
