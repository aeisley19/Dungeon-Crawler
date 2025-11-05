using UnityEngine;

public class PlayerLocater : MonoBehaviour
{
    [SerializeField] private float radius;
    
    public bool Locate(GameObject origin)
    {
        return Physics2D.OverlapCircle(origin.transform.position, radius, LayerMask.GetMask("Player"));
    }
}
