using UnityEngine;

namespace _Game.Scripts.ExplosionStrategy
{
    public class ExplosionImpulse : IExplosion
    {
        private readonly float _explosionForce;
        private readonly float _explosionRadius;
        private readonly float _upwardsModifier;

        public ExplosionImpulse(float explosionForce, float explosionRadius, float upwardsModifier = 1f)
        {
            _explosionForce = explosionForce;
            _explosionRadius = explosionRadius;
            _upwardsModifier = upwardsModifier;
        }

        public void Execute(IExplodable explodable, Vector3 explosionPoint)
        {
            explodable.Explode(_explosionForce, explosionPoint, _explosionRadius, _upwardsModifier);
        }
    }
}