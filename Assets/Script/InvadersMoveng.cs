using System;

public class InvadersMoveng
{
    public event Action MovingChanged;
    public void InvaderTouchBoundary()
    {
        MovingChanged?.Invoke();
    }
}
