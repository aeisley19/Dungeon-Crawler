using System.Collections;
using UnityEngine;

public class ActionCooldown : MonoBehaviour
{
    private bool isActionable = true;

    public void InitiateCooldown(float cooldownTimer)
    {
        isActionable = false;
        StartCoroutine(CoolDown(cooldownTimer));
    }

    public IEnumerator CoolDown(float cooldownTimer)
    {
        yield return new WaitForSeconds(cooldownTimer);
        isActionable = true;
    }

    public bool CooldownIsComplete()
    {
        return isActionable;
    }
}