using UnityEngine;

public class DamageEvent : IAnimationListener
{

    private readonly AnimationEventHandler eventHandler;
    private readonly DamageHandler dmg;
    private readonly KnockbackHandler knockback;
    private readonly HealthManager health;
    private readonly Animator anim;
    private readonly Rigidbody2D rb;
    protected float inflictedDamage;
    protected bool isDead = false;

    public DamageEvent(DamageHandler dmg, HealthManager health, Animator anim, Rigidbody2D rb)
    {
        this.dmg = dmg;
        this.health = health;
        this.anim = anim;
        this.rb = rb;
        knockback = new KnockbackHandler(rb);
        eventHandler = new AnimationEventHandler(anim);
    }
    
    public virtual void EnterHandler()
    {
        eventHandler.Subscribe(this);
        anim.SetBool("isDamaged", dmg.IsTriggered);
        knockback.Knockback(dmg.Collider, 10);

        inflictedDamage = dmg.Collider.gameObject.GetComponent<DamageToInflict>().Damage;
        health.LoseHealth(inflictedDamage);
    }

    public void ExitHandler()
    {
        eventHandler.UnSubscribe(this);
        anim.SetBool("isDamaged", dmg.IsTriggered);
        rb.linearVelocity = Vector2.zero;
    }

    public void OnAnimationEvent(string animationEvent)
    {
        if (animationEvent == "EndDamage") dmg.SetIsCollision(false);
    }
}
