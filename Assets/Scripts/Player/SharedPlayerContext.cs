using UnityEngine;

public class SharedPlayerContext
{
    public Vector3 FacingDir { get; private set; }
    public Animator Animator { get; }

    public SharedPlayerContext(Animator animator)
    {
        Animator = animator;
        FacingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
    }

    public void SetFacingDir(Vector3 facingDir)
    {
        if (facingDir != Vector3.zero) FacingDir = facingDir;
    }
}
