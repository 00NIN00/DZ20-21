using UnityEngine;

namespace _Game.Scripts.Shooter
{
    public class ShooterExplosion
    {
        private const float MinDistance = 0.1f;
        
        private readonly float _explosionRadius;
        private readonly float _explosionForce;
        private readonly float _upwardsModifier = 1;
    
        private ParticleSystem _particleSystem;
        

        public ShooterExplosion(float radius, float force, ParticleSystem particleSystem)
        {
            _explosionRadius = radius;
            _explosionForce = force;
            _particleSystem = particleSystem;
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
                        if (collider.TryGetComponent(out IExplosioned explosioned))
                        {
                           //Explosion1(collider, explosioned, hit.point);
                           Explosion2(explosioned, hit.point);
                        }
                    }
                }
            }
        }

        private void Explosion1(Collider collider, IExplosioned explosioned, Vector3 position)
        {
            Vector3 objectPosition = collider.transform.position;

            Vector3 directionForce = (objectPosition - position).normalized;
                            
            explosioned.Explode(directionForce, _explosionForce);
        }

        private void Explosion2(IExplosioned explosioned, Vector3 position)
        {
            explosioned.Explode(_explosionForce, position, _explosionRadius, _upwardsModifier);
        }
    }
}