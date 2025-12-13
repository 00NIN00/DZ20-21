using System;
using UnityEngine;

public class InputPC : IInput
{
    private const int MouseRight = 0;
    private const int MouseLeft = 1;
    
    public Vector2 Position => Input.mousePosition;
    public bool Button1 => GetMouseInput(MouseRight);
    public bool Button1Hold => GetMouseHoldInput(MouseRight);
    public bool Button2 => GetMouseInput(MouseLeft);

    private bool GetMouseInput(int typeMouse)
    {
        return Input.GetMouseButtonDown(typeMouse);
    }
    private bool GetMouseHoldInput(int typeMouse)
    {
        return Input.GetMouseButton(typeMouse);
    }
}