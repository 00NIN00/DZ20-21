using UnityEngine;

namespace _Game.Scripts.Shooter
{
    public class ShooterDrag : IShooter
    {
        private Transform _target;
    
        private float _zCoordinate;
        private Camera Camera => Camera.main;

        public void Cast(Vector2 position)
        {
            Ray ray = Camera.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out IInteracted _))
                {
                    _target = hit.collider.gameObject.transform;
                
                    _target.rotation = Quaternion.identity;
                
                    _zCoordinate = Camera.WorldToScreenPoint(_target.position).z;
                }
            }

            Drag(position);
        }

        private void Drag(Vector2 position)
        {
            if (_target != null)
            {
                _target.position = GetMouseWorldPosition(position);
            }
        }

        private Vector3 GetMouseWorldPosition(Vector2 screenPosition)
        {
            Vector3 mousePoint = screenPosition;
            mousePoint.z = _zCoordinate;
            return Camera.ScreenToWorldPoint(mousePoint);
        }
    }
}