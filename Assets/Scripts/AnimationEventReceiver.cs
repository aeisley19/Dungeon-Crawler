using System;
using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
    public event Action<String> OnAnimationEvent;

    public void AnimationEvent(String animationEvent)
    {
        OnAnimationEvent?.Invoke(animationEvent);
    }
}
