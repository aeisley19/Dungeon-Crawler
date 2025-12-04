using UnityEngine;

public class SpinnerWallDetector : CollisionHandler
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(collisionTag)) IsTriggered = true;
    }
}
