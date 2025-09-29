using UnityEngine;

public class KnockbackHandler
{
    private readonly float knockBackForce = 5;
    private readonly Rigidbody2D rb;

    public KnockbackHandler(Rigidbody2D rb)
    {
        this.rb = rb;
    }

    public void Knockback(Collider2D other)
    {
        Vector2 direction = (rb.position - (Vector2)other.transform.position).normalized;
        rb.AddForce(direction * knockBackForce, ForceMode2D.Impulse);
    }
}
