using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    [SerializeField] private string collisionTag;

    public bool IsDamaged { get; private set; }
    public Collider2D Other { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(collisionTag))
        {
            IsDamaged = true;
            Other = other;
            print("time " + IsDamaged);
        }
    }

    public void SetIsDamaged(bool isDamaged)
    {
        IsDamaged = isDamaged;
    }
}
