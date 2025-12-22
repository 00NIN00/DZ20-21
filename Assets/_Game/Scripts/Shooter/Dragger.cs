using UnityEngine;

namespace _Game.Scripts.Shooter
{
    public class Dragger
    {
        private Plane _dragPlane; 
        private IDraggable _draggable;

        private Camera Camera => Camera.main;
        
        public void Cast(Vector2 position)
        {
            Ray ray = CameraRay(position);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out IDraggable draggable))
                {
                    _draggable = draggable;
                    _draggable.StartDrag();
                    
                    Vector3 planeCenter = _draggable.Position;
                    
                    _dragPlane = new Plane(Vector3.up, planeCenter);
                }
            }
        }
    
        public void Drag(Vector2 position)
        {
            if (_draggable == null ) return;

           Ray ray = CameraRay(position);
            
            if (_dragPlane.Raycast(ray, out float distance))
            {
                Vector3 worldPoint = ray.GetPoint(distance);
                _draggable.Drag(worldPoint);
            }
        }
        
        private Ray CameraRay(Vector3 position) => Camera.ScreenPointToRay(position);

        public void Release()
        {
            _draggable?.EndDrag();
            _draggable = null;
            _dragPlane = new Plane();
        }
    }
}