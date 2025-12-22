using UnityEngine;

namespace _Game.Scripts
{
    public interface IExplosioned
    {
        void Explode(Vector3 direction, float explosionForce);
    }
}