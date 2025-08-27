using System;
using UnityEngine;

public class AnimationEventHandler
{
    private readonly AnimationEventReceiver eventReceiver;

    public AnimationEventHandler(Animator animator)
    {
        eventReceiver = animator.GetComponent<AnimationEventReceiver>();
    }

    public void Subscribe(IAnimationListener listener)
    {
        if(eventReceiver != null) eventReceiver.OnAnimationEvent += listener.OnAnimationEvent;
    }

    public void UnSubscribe(IAnimationListener listener)
    {
        if (eventReceiver != null) eventReceiver.OnAnimationEvent -= listener.OnAnimationEvent;
    }
}
