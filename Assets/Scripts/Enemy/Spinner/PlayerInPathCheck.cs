using UnityEngine;

public class PlayerInPathCheck : MonoBehaviour
{
    private bool isTriggered;

    public void SetIsTriggered(bool triggered)
    {
        isTriggered = triggered;
    }

    public bool IsTriggered()
    {
        return isTriggered;
    }
}
