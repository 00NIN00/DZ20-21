using UnityEngine;

namespace _Game.Scripts.ExplosionStrategy
{
    public interface IExplosionStrategy
    {
        void Execute(IExplodable explodable, Vector3 explosionPoint);
    }
}