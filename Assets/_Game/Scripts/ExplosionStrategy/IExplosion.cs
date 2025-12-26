using UnityEngine;

namespace _Game.Scripts.ExplosionStrategy
{
    public interface IExplosion
    {
        void Execute(IExplodable explodable, Vector3 explosionPoint);
    }
}