using UnityEngine;

public class StatusContext
{
    public float Health { get; private set; }
    public StatusContext(float health)
    {
        Health = health; 
    }
}
