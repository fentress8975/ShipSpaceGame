using UnityEngine;
public interface IControllable
{
    public void Movement(Vector2 axis);
    public void FireWeapon();
}

public enum MovementCommands
{
    Acceleration,
    Deceleration,
    RotateLeft,
    RotateRight,
    FireWeapon
}
