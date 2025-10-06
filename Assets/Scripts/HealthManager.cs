using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int maxHearts;
    private float hearts;

    public void Awake()
    {
        hearts = maxHearts;
    }

    public float Hearts { get { return hearts; } }
    public int MaxHearts { get { return maxHearts; } }

    public virtual void ReplenishHealth(int healAmount)
    {
        if (healAmount + hearts <= maxHearts) hearts += healAmount;
        else hearts = maxHearts;
    }

    public void LoseHealth(float damageAmount)
    {
        if (damageAmount >= hearts) hearts = 0;
        else hearts -= damageAmount;
    }

    public void IncrementMaxHealth()
    {
        maxHearts++;
    }
}