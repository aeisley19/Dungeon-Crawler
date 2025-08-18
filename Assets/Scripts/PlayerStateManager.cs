using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerStates currentState;

    public enum PlayerStates
    {
        IdleState,
        WalkState,
        attackState
    }

    public PlayerStates getState()
    {
        return currentState;
    }
}
