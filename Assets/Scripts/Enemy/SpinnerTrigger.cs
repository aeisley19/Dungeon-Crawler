using Unity.VisualScripting;
using UnityEngine;

public class SpinnerTrigger : CollisionHandler, ITriggerable
{
    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(collisionTag)) IsTriggered = true;
    } 

    public void OnTriggerExit2D(Collider2D other) {
        IsTriggered = false;
    }
}
