using UnityEngine;

public interface IInput
{
    public Vector2 Position { get; }

    public bool Button1 { get; }
    public bool Button1Hold { get; }
    
    public bool Button2 { get; }
}