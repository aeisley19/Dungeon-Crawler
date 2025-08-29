using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEditor.Rendering.LookDev;

public abstract class StateManager<EState, TContext> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, AbstractState<EState, TContext>> states;
    protected AbstractState<EState, TContext> currentState;
    protected bool isTransitioningStates = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        EState nextStateKey = currentState.GetNextState();

        if (nextStateKey.Equals(currentState.StateKey)) currentState.UpdateState();
        else if (!isTransitioningStates) TransitionToState(nextStateKey);

        print(currentState);
    }

    public void TransitionToState(EState stateKey)
    {
        isTransitioningStates = true;
        currentState.ExitState();
        currentState = states[stateKey];
        currentState.EnterState();
        isTransitioningStates = false;
    }
}
