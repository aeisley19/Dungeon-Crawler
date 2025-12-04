using UnityEngine;

public abstract class AbstractDectectPlayer 
{
    public abstract bool Detect(Vector2 origin, float dir);

    public abstract bool DetectPlayerCast(Vector2 origin, Vector2 direction);
}
