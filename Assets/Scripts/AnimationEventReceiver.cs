using System;
using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
    public event Action<AnimationEvent> OnAnimationEnded;

    public void OnAnimationEnd(AnimationEvent animationEvent)
    {
        OnAnimationEnded?.Invoke(animationEvent);
    }
}
