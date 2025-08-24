using UnityEngine;

public class KeyboardInput
{
    public Vector2 getMovementInput() => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    
    public bool AttackInput() => Input.GetKeyDown(KeyCode.Z);
}
