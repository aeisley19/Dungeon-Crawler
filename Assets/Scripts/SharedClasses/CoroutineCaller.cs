using System.Collections;
using UnityEngine;

public class CoroutineCaller : MonoBehaviour
{
    public static CoroutineCaller Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void Run(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
