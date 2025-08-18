using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, AbstractState<EState>> States;
    protected AbstractState<EState> currentState;
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

        if (currentState.Equals(currentState.GetNextState()))
        {
            currentState.UpdateState();
        }
        else if(!isTransitioningStates)
        {
            TransitionToState(nextStateKey);   
        }
    }

    public void TransitionToState(EState stateKey)
    {
        isTransitioningStates = true;
        currentState.ExitState();
        currentState = States[stateKey];
        currentState.EnterState();
        isTransitioningStates = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }

    private  void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }
}
