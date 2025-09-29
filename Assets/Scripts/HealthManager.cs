using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float hearts;

    public float Hearts { get; }

    public virtual void ReplenishHealth(float healAmount)
    {
        hearts += healAmount;
    }

    public void LoseHealth(float damageAmount)
    {
        hearts -= damageAmount;
    }
}