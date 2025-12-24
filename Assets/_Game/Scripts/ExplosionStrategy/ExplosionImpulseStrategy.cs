using UnityEngine;

namespace _Game.Scripts.ExplosionStrategy
{
    public class ExplosionImpulseStrategy : IExplosionStrategy
    {
        private readonly float _explosionForce;
        private readonly float _explosionRadius;
        private readonly float _upwardsModifier;

        public ExplosionImpulseStrategy(float explosionForce, float explosionRadius, float upwardsModifier = 1f)
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