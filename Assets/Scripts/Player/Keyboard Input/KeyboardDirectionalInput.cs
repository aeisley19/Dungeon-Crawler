using UnityEngine;

public class KeyboardDirectionalInput
{
    public Vector2 GetMovementInput() => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
}
