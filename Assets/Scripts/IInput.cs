using UnityEngine;

public interface IInput
{
    public Vector2 Position { get; }

    public bool Button1 { get; }
    public bool ButtonHold { get; }
}