using UnityEngine;

public abstract class EnemyIdleState : AbstractState<EnemyStates, EnemyContext>
{
    public EnemyIdleState(EnemyContext ctx) : base(EnemyStates.IDLESTATE)
    {
        this.ctx = ctx;
    }

    public override EnemyStates GetNextState()
    {
        throw new System.NotImplementedException();
    }
}
