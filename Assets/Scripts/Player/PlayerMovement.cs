using UnityEngine;

public class PlayerMovement
{
    private readonly Rigidbody2D rb;
    private readonly float runSpeed;

    public PlayerMovement(Rigidbody2D rb, float runSpeed)
    {
        this.rb = rb;
        this.runSpeed = runSpeed;
    }
    
    public void Move(Vector2 dir)
    {
        if(dir == Vector2.zero) return;
        
        rb.MovePosition(rb.position + runSpeed * Time.deltaTime * dir);
    }
}
