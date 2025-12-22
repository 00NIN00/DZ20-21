using UnityEngine;

namespace _Game.Scripts.Shooter
{
    public class ShooterDrag
    {
        private Vector3 _offset;
        private float _zCoordinate;
        
        private IDraggable _draggable;
        private Camera Camera => Camera.main;
    
        public void Cast(Vector2 position)
        {
            Ray ray = Camera.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out IDraggable interacted))
                {
                    _draggable = interacted;
                    
                    _draggable.StartDrag();
                    
                    _zCoordinate = Camera.WorldToScreenPoint(_draggable.Position).z;
                
                    _offset = _draggable.Position - GetMouseWorldPosition(position);
                }
            }
        }
    
        public void Drag(Vector2 position)
        {
            if (_draggable != null)
            {
                _draggable.Drag(GetMouseWorldPosition(position) + _offset);
            }
        }
    
        private Vector3 GetMouseWorldPosition(Vector2 screenPosition)
        {
            Vector3 mousePoint = screenPosition;
            mousePoint.z = _zCoordinate;
        
            return Camera.ScreenToWorldPoint(mousePoint);
        }

        public void Release()
        {
            _draggable?.EndDrag();
            _draggable = null;
        }
    }
}