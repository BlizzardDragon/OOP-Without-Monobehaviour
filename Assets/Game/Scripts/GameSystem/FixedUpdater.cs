using System;
using FrameworkUnity.OOP.Interfaces.Listeners;

public class FixedUpdater : IFixedUpdateGameListener
{
    public event Action<float> OnFixedUpdateEvent;

    public void OnFixedUpdate(float fixedDeltaTime) => OnFixedUpdateEvent?.Invoke(fixedDeltaTime);
}
