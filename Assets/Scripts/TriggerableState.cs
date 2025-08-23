using UnityEngine;

public interface TriggerableState
{
    public virtual void TriggerEnter(Collider other) {}
    public virtual void TriggerStay(Collider other) {}
    public virtual void TriggerExit(Collider other) {}
}
