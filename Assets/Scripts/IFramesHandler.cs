using UnityEngine;
using System.Collections;

public class IFramesHandler
{
    private readonly float iframesTimer = 1f;
    private readonly Collider2D col;

    public IFramesHandler(Collider2D col)
    {
        this.col = col;
    }

    public IEnumerator InitializeIFrames()
    {
        Debug.Log("iframes");
        col.enabled = false;
        yield return new WaitForSeconds(iframesTimer);
        col.enabled = true;
    }
}
