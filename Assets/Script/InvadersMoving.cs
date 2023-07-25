using System;

public class InvadersMoving
{
    public event Action MovingChanged;
    public void InvaderTouchBoundary()
    {
        MovingChanged?.Invoke();
    }
}
