using UnityEngine;

public class KeyboardInput
{
    public Vector2 GetMovementInput() => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    public bool GetAttackInput() => Input.GetKeyDown(KeyCode.Z);
}
