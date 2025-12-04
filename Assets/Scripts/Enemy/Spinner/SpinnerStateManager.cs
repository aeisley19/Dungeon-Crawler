using UnityEngine;
using System.Collections.Generic;

public enum SpinnerStates
{
    IDLESTATE,
    ATTACKSTATE,
    RETURNSTATE
}

public class SpinnerStateManager : AbstractStateManager<SpinnerStates, SpinnerContext>
{
    [SerializeField] private GameObject origin;
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private PlayerInPathCheck pathChecker;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector2 direction;
    [SerializeField] private SpinnerTrigger spinnerTrigger;
    private SpinnerContext ctx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        ctx = new SpinnerContext(gameObject, rb, animator, direction, spinnerTrigger);

        states = new Dictionary<SpinnerStates, AbstractState<SpinnerStates, SpinnerContext>>
        {
            { SpinnerStates.IDLESTATE, new SpinnerIdleState(ctx) },
            { SpinnerStates.ATTACKSTATE, new SpinnerAttackState(ctx)},
            { SpinnerStates.RETURNSTATE, new SpinnerReturnState(ctx)}
        };

        currentState = states[SpinnerStates.IDLESTATE];

        base.Start();
    }
}
