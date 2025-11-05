using UnityEngine;

public class DetectCanMove : MonoBehaviour
{
    private RaycastHit2D hitWall; 

    public Vector2 ChooseDirection()
    {
        return Vector2.zero;   
    }
    public bool CanMove(Vector2 dir)
    {
        hitWall = Physics2D.Raycast(gameObject.transform.position, dir, 2);

        return true;       
    }
}
