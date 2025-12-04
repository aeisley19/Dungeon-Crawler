using UnityEngine;

public interface ICollidable
{
    public void OnCollisionEnter2D(Collision2D other);
}
