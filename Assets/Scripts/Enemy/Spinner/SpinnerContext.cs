using System.Net;
using UnityEngine;

public class SpinnerContext : AbstractContext
{
    public GameObject[] EndPoints { get; }
    public Vector2 Direction { get; private set; }
    public Rigidbody2D Rb { get; }
    public Animator Animator { get; }
    public Vector2 Origin { get; }
    public SpinnerTrigger SpinnerTrigger { get; }

    public SpinnerContext(GameObject gameObject, Rigidbody2D rb, Animator animator,
        Vector2 direction, SpinnerTrigger spinnerTrigger) : base(gameObject)
    {
        Rb = rb;
        Origin = Rb.position;
        Animator = animator;
        Direction = direction;
        SpinnerTrigger = spinnerTrigger;
    }

    public void SetDirection(Vector2 dir)
    {
        Direction = dir;
    }
}
