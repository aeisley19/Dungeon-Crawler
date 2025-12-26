using UnityEngine;

public class PlayerFinder
{
    private readonly GameObject self;
    private readonly GameObject player;

    public PlayerFinder(GameObject self, GameObject player)
    {
        this.self = self;
        this.player = player;
    }
    
    public Vector2 GetDirection()
    {
        Vector2 heading = -(self.transform.position - player.transform.position);
        float distance = heading.magnitude;
        Vector2 dir = heading / distance;
        dir.Normalize();

        return dir;
    }
}
