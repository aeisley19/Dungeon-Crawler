using UnityEngine;

public interface ISharedContext
{
    public float RunSpd { get; }
    public Rigidbody2D Rb { get; }
    public Collider2D Col { get; } 
    public HealthManager Health { get; }
    public DamageHandler DamageHandler { get; } 
    public Animator Animator { get; }
}
