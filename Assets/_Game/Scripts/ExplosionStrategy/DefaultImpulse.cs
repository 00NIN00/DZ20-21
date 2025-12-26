using UnityEngine;

namespace _Game.Scripts.ExplosionStrategy
{
    public class DefaultImpulse : IExplosion
    {
        private readonly float _explosionForce;

        public DefaultImpulse(float explosionForce)
        {
            _explosionForce = explosionForce;
        }

        public void Execute(IExplodable explodable, Vector3 explosionPoint)
        {
            Vector3 objectPosition = explodable.Position;
            Vector3 direction = (objectPosition - explosionPoint).normalized;
            
            explodable.Explode(direction, _explosionForce);
        }
    }
}