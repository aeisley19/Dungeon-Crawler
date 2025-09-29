using UnityEngine;

public class RotateHitBox : MonoBehaviour
{
    public void Rotate(Vector2 input)
    {
        Vector2 direction = input.x * Vector2.left + input.y * Vector2.down;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }
}
