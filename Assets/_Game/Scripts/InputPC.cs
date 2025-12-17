using UnityEngine;

namespace _Game.Scripts
{
    public class InputPC : IInput
    {
        private const int MouseRight = 0;
        private const int MouseLeft = 1;
        private const KeyCode SwitchCameraKey = KeyCode.F;
    
        public Vector2 Position => Input.mousePosition;
        public bool Button1 => GetMouseInput(MouseRight);
        public bool Button1Hold => GetMouseHoldInput(MouseRight);
        public bool Button2 => GetMouseInput(MouseLeft);
        public bool SwitchCamera => Input.GetKeyDown(SwitchCameraKey);

        private bool GetMouseInput(int typeMouse)
        {
            return Input.GetMouseButtonDown(typeMouse);
        }
        private bool GetMouseHoldInput(int typeMouse)
        {
            return Input.GetMouseButton(typeMouse);
        }
    }
}