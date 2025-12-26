using UnityEngine;

namespace _Game.Scripts
{
    public class InputPC : IInput
    {
        private const int MouseLeft = 0;
        private const int MouseRight = 1;
        private const KeyCode SwitchCameraKey = KeyCode.F;
        private const KeyCode SwitchExplosionTypeKey = KeyCode.Q;
    
        public Vector2 Position => Input.mousePosition;
        public bool Button1 => GetMouseInput(MouseLeft);
        public bool Button1Hold => GetMouseHoldInput(MouseLeft);
        public bool Button2 => GetMouseInput(MouseRight);
        public bool SwitchCamera => Input.GetKeyDown(SwitchCameraKey);
        public bool SwitchExplosionType => Input.GetKeyDown(SwitchExplosionTypeKey);

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