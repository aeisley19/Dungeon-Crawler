public class PlayerDamagedState : AbstractState<PlayerStates, PlayerContext>
{
    private readonly IFramesHandler iFrames;
    private readonly DamageEvent damageEvent;

    public PlayerDamagedState(PlayerContext ctx) : base(PlayerStates.DAMAGEDSTATE)
    {
        this.ctx = ctx;
        iFrames = new IFramesHandler(ctx.Col);
        damageEvent = new DamageEvent(ctx.DamageHandler, ctx.Health, ctx.Animator, ctx.Rb);
    }

    public override void EnterState()
    {
        damageEvent.EnterHandler();
        CoroutineCaller.Instance.Run(iFrames.InitializeIFrames());
        ctx.UI.DamageUI(0.5f);
    }

    public override void ExitState()
    {
        damageEvent.ExitHandler();
    }

    public override PlayerStates GetNextState()
    {
        // if (ctx.Health.Hearts <= 0) return PlayerStates.DEATHSTATE;
        if (!ctx.DamageHandler.IsDamaged) return PlayerStates.IDLESTATE;

        return PlayerStates.DAMAGEDSTATE;
    }
}
