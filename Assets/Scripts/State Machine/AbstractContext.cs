using UnityEngine;

public abstract class AbstractContext
{
    public GameObject GameObject { get; protected set; }

    public AbstractContext(GameObject gameObject) => GameObject = gameObject;
}
