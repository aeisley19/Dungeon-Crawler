using UnityEngine;

public class MovementAnimation
{
    private readonly Animator animator;

    public MovementAnimation(Animator animator) => this.animator = animator;

    public void SetMovementDirection(Vector2 moveDir)
    {
        animator.SetFloat("moveX", moveDir.x);
        animator.SetFloat("moveY", moveDir.y);
    }
}
