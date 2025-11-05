using UnityEngine;

public class DamageEvent : IAnimationListener
{

    private readonly AnimationEventHandler eventHandler;
    private readonly IAnimationListener listen;
    private readonly DamageHandler dmg;
    private readonly KnockbackHandler knockback;
    private readonly HealthManager health;
    private readonly Animator anim;
    private readonly Rigidbody2D rb;

    public DamageEvent(DamageHandler dmg,
        HealthManager health, Animator anim, Rigidbody2D rb)
    {
        this.dmg = dmg;
        this.health = health;
        this.anim = anim;
        this.rb = rb;
        knockback = new KnockbackHandler(rb);
        eventHandler = new AnimationEventHandler(anim);
    }
    
    public void EnterHandler()
    {
        eventHandler.Subscribe(this);
        anim.SetBool("isDamaged", dmg.IsDamaged);
        knockback.Knockback(dmg.Other, 10);
        health.LoseHealth(0.5f); //Change later. You need dynamic damage.
    }

    public void ExitHandler()
    {
        eventHandler.UnSubscribe(this);
        anim.SetBool("isDamaged", dmg.IsDamaged);
        rb.linearVelocity = Vector2.zero;
    }

    public void OnAnimationEvent(string animationEvent)
    {
        
        if (animationEvent == "EndDamage") dmg.SetIsDamaged(false);
    }
}
