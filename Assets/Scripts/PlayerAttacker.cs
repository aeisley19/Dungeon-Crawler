using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        animator.SetBool("isAttacking", true);
    }

    public void EndAttack()
    {
        animator.SetBool("isAttacking", false); 
    }
}
