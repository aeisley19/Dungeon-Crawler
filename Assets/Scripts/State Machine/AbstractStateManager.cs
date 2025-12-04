using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AbstractStateManager<EState, TContext> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, AbstractState<EState, TContext>> states;
    protected AbstractState<EState, TContext> currentState;
    protected bool isTransitioningStates = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
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

    public void TransitionToState(EState stateKey)
    {
        Debug.Log(currentState);
        isTransitioningStates = true;
        currentState.ExitState();
        currentState = states[stateKey];
        currentState.EnterState();
        isTransitioningStates = false;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(currentState is ICollidable collidable) collidable.OnCollisionEnter2D(other);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(currentState is ITriggerable triggerable) triggerable.OnTriggerEnter2D(other);
    }
}
