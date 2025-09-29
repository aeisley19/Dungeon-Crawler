using UnityEngine;

public class MovementAnimation
{
    private readonly Animator animator;

    public MovementAnimation(Animator animator) => this.animator = animator;

    public void SetMovementDirection(Vector2 moveDir)
    {
        if(animator.GetFloat("moveY") == 0) animator.SetFloat("moveX", moveDir.x);
        if(animator.GetFloat("moveX") == 0) animator.SetFloat("moveY", moveDir.y);
    }
}
