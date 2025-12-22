using UnityEngine;

namespace _Game.Scripts
{
    public interface IDraggable
    {
        Vector3 Position { get; }
        void StartDrag();
        public void Drag(Vector3 position);
        
        void EndDrag();
    }
}
