using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] protected string collisionTag;

    public virtual bool IsTriggered { get; protected set; }

    public virtual void SetIsCollision(bool isTriggered)
    {
        IsTriggered = isTriggered;
    }
}
