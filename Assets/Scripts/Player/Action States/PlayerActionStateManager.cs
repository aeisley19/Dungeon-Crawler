using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerActionStates
{
    INACTIVESTATE,
    ATTACKSTATE
}
public class PlayerActionStateManager : StateManager<PlayerActionStates>
{
    public void Awake()
    {
        states = new Dictionary<PlayerActionStates, AbstractState<PlayerActionStates>>()
        {
            {PlayerActionStates.ATTACKSTATE, new PlayerAttackState(null) }
        };
    }
}
