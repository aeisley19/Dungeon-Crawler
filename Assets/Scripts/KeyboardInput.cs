using UnityEngine;

public class KeyboardInput
{
    public Vector2 getMovementInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
