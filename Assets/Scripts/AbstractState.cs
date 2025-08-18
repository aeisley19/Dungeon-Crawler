using Unity.VisualScripting;
using UnityEngine;
using System;

public abstract class AbstractStateMachine<EState> where EState : Enum
{
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState GetNextState();
    public abstract void OnTriggerStay();
    public abstract void OnTriggerExit();
}
