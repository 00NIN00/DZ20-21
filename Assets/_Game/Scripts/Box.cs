using UnityEngine;

namespace _Game.Scripts
{
    public class Box : MonoBehaviour, IDraggable,  IExplosioned
    {
        private Rigidbody _rigidbody;
        public Vector3 Position => transform.position;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void StartDrag()
        {
            _rigidbody.isKinematic = true;
            
            transform.rotation = Quaternion.identity;
        }

        public void Drag(Vector3 position)
        {
            transform.position = position;
        }

        public void EndDrag()
        {
            _rigidbody.isKinematic = false;
        }

        public void Explode(Vector3 direction, float explosionForce)
        {
            _rigidbody.AddForce(direction * explosionForce, ForceMode.Impulse);
        }
    }
}
