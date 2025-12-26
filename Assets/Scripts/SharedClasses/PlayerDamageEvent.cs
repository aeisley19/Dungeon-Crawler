using UnityEngine;

public class PlayerDamageEvent : DamageEvent
{
    private readonly HealthUI ui;

    public PlayerDamageEvent(DamageHandler dmg, HealthManager health, Animator anim, Rigidbody2D rb, HealthUI ui) : 
        base(dmg, health, anim, rb)
    {
        this.ui = ui; 
    }

    public override void EnterHandler () 
    {
        base.EnterHandler();

        ui.DamageUI(inflictedDamage);    
    }
}
