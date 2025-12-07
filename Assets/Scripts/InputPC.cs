using UnityEngine;

public class InputPC : IInput
{
    private const int MouseRight = 0;
    private const int MouseLeft = 1;
    
    public Vector2 Position => Input.mousePosition;
    public bool Button1 => GetMouseRightInput();
    public bool ButtonHold => GetMouseRightHoldInput();

    private bool GetMouseRightInput()
    {
        return Input.GetMouseButtonDown(MouseRight);
    }
    private bool GetMouseRightHoldInput()
    {
        return Input.GetMouseButton(MouseRight);
    }
}