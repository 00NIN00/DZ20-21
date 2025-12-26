using _Game.Scripts.ExplosionStrategy;
using UnityEngine;

namespace _Game.Scripts.Shooter
{
    public class ShooterExplosion
    {
        private readonly float _explosionRadius;
        private readonly ParticleSystem _particleSystem;
        private IExplosion _explosion;

        public ShooterExplosion(float radius, ParticleSystem particleSystem)
        {
            _explosionRadius = radius;
            _particleSystem = particleSystem;
        }
    
        private Camera Camera => Camera.main;
    
        public void Cast(Vector2 position)
        {
            if (_explosion == null)
                return;
            
            Ray ray = Camera.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider != null)
                {
                    _particleSystem.transform.position = hit.point;
                    _particleSystem.Play();
                    
                    Collider[] colliders = Physics.OverlapSphere(hit.point, _explosionRadius);
                    
                    foreach (Collider collider in colliders)
                    {
                        if (collider.TryGetComponent(out IExplodable explodable))
                        {
                            _explosion.Execute(explodable, hit.point);   
                        }
                    }
                }
            }
        }

        public void SetExplosionType(IExplosion explosion)
        {
            if (explosion == _explosion && explosion == null)
                return;
            
            _explosion = explosion;
        }
    }
}