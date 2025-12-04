using UnityEngine;

public class DetectPlayerInsideBounds
{
    public bool Detect(GameObject origin, float radius)
    {
        return Physics2D.OverlapCircle(origin.transform.position, radius, LayerMask.GetMask("Player"));
    }
}
