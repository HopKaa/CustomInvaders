using System;

public class CommonInvadersMovingEvent
{
    public event Action MovingChanged;
    public void InvaderTouchBoundary()
    {
        MovingChanged?.Invoke();
    }
}