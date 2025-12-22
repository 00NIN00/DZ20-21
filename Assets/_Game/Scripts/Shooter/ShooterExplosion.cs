using UnityEngine;

namespace _Game.Scripts.Shooter
{
    public class ShooterExplosion
    {
        private const float MinDistance = 0.1f;
        
        private readonly float _explosionRadius;
        private readonly float _explosionForce;
        private readonly float _upwardsModifier = 1;
        private readonly ParticleSystem _particleSystem;
        
        private readonly SwitcherExplosion _switcherExplosion;
        private TypeExplosion _typeExplosion => _switcherExplosion.TypeExplosion;
        

        public ShooterExplosion(float radius, float force, ParticleSystem particleSystem, SwitcherExplosion  switcherExplosion)
        {
            _explosionRadius = radius;
            _explosionForce = force;
            _particleSystem = particleSystem;
            _switcherExplosion = switcherExplosion;
        }
    
        private Camera Camera => Camera.main;
    
        public void Cast(Vector2 position)
        {
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
                            switch (_typeExplosion)
                            {
                                case TypeExplosion.DefaultImpulse:
                                    Explosion1(collider, explodable, hit.point);
                                    break; 
                                case TypeExplosion.ExplosionImpulse:
                                    Explosion2(explodable, hit.point);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void Explosion1(Collider collider, IExplodable explodable, Vector3 position)
        {
            Vector3 objectPosition = collider.transform.position;

            Vector3 directionForce = (objectPosition - position).normalized;
                            
            explodable.Explode(directionForce, _explosionForce);
        }

        private void Explosion2(IExplodable explodable, Vector3 position)
        {
            explodable.Explode(_explosionForce, position, _explosionRadius, _upwardsModifier);
        }
    }
}