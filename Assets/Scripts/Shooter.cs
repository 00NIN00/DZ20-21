using UnityEngine;

public class Shooter
{
    private Transform _target;  
    private Vector3 _offset;
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

                _zCoordinate = Camera.WorldToScreenPoint(_target.position).z;
                
                _offset = _target.position - GetMouseWorldPosition(position);
            }
        }
    }
    
    public void Drag(Vector2 position)
    {
        if (_target != null)
        {
            _target.position = GetMouseWorldPosition(position) + _offset;
        }
    }
    
    private Vector3 GetMouseWorldPosition(Vector2 screenPosition)
    {
        Vector3 mousePoint = screenPosition;
        mousePoint.z = _zCoordinate;
        
        return Camera.ScreenToWorldPoint(mousePoint);
    }
}
