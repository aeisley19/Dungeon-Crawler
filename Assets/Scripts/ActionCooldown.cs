using System.Collections;
using UnityEngine;

public class ActionCooldown : MonoBehaviour
{
    private float coolDownTimer = 0;
    private bool isActionable = true;

    public void InitiateCooldown(float cooldownTimer)
    {
        this.coolDownTimer = cooldownTimer;

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