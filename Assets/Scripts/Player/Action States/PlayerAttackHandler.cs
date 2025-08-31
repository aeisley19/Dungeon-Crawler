using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour
{

    public PlayerAttackHandler()
    {

    }

    public Collider2D Attack(Animator animator)
    {
        return Physics2D.OverlapCircle(gameObject.transform.position, 1);
    }

 }
