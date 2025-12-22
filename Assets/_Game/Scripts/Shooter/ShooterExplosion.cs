using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Shooter
{
    public class ShooterExplosion
    {
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
                            Vector3 direction = (collider.transform.position - hit.point).normalized;
                    
                            explosioned.Explode(direction, _explosionForce);
                        }
                    }
                }
            }
        }
    }
}