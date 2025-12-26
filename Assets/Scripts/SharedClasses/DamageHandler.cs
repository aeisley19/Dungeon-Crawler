using UnityEngine;

public class DamageHandler : CollisionHandler
{
    public Collider2D Collider { get; protected set; }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(collisionTag))
        {
            IsTriggered = true;
            Collider = other;
        }
    }
}
