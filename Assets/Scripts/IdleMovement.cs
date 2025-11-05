using UnityEngine;

public class IdleMovement 
{
    private float moveX;
    private float moveY;

    public IdleMovement() 
    {
        moveX = Random.Range(-1, 1);
        moveY = Random.Range(-1, 1);
    }
    
    /*public IEnumerator Move() 
    {
        moveX = Random.Range(-1, 1);
        moveY = Random.Range(-1, 1);
    }*/
}
