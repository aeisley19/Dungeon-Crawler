using UnityEngine;

public class StatusContext
{
    public float Health { get; private set; }
    public Collider2D Col { get; private set; }

    public StatusContext(float health, Collider2D col)
    {
        Health = health;
        Col = col;
    }
}
