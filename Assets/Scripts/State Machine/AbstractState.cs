using Unity.VisualScripting;
using UnityEngine;
using System;

public abstract class AbstractState<EState, TContext> where EState : Enum
{
    protected TContext ctx;

     public AbstractState(EState state)
    {
        StateKey = state;
    }

    public EState StateKey { get; private set; }
    public virtual void EnterState() { }
    public virtual void ExitState() {}
    public virtual void UpdateState() {}
    public abstract EState GetNextState();
}
