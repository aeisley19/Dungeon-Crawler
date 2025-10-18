using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamagedState : AbstractDamagedState<PlayerStates, PlayerContext>//AbstractState<PlayerStates, PlayerContext>, IAnimationListener
{
    private readonly IFramesHandler iFrames;

    public PlayerDamagedState(PlayerContext ctx) : base(PlayerStates.DAMAGEDSTATE, ctx)
    {
        this.ctx = ctx;
        iFrames = new IFramesHandler(ctx.Col);
    }

    public override void EnterState()
    {
        base.EnterState();
        CoroutineCaller.Instance.Run(iFrames.InitializeIFrames());
        ctx.UI.DamageUI(0.5f);
    }

    public override PlayerStates GetNextState()
    {
        // if (ctx.Health.Hearts <= 0) return PlayerStates.DEATHSTATE;
        if (!ctx.DamageHandler.IsDamaged) return PlayerStates.IDLESTATE;
        
        return PlayerStates.DAMAGEDSTATE;
    }
}
