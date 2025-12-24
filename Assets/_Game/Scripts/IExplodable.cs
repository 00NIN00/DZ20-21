using UnityEngine;

namespace _Game.Scripts
{
    public interface IExplodable
    {
        public Vector3 Position { get; }
        
        void Explode(Vector3 direction, float explosionForce);
        void Explode(float explosionForce, Vector3 position, float explosionRadius, float upwardsModifier);
    }
}