using System;
using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
    public event Action<string> OnAnimationEvent;

    public void AnimationEvent(string animationEvent)
    {
        OnAnimationEvent?.Invoke(animationEvent);
    }
}
