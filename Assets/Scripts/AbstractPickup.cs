using UnityEngine;

public abstract class AbstractPickup : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Damageable"))
        {
            PickupAction();
        }
    }

    public abstract void PickupAction();
}
