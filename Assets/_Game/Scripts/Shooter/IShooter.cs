using UnityEngine;

namespace _Game.Scripts.Shooter
{
    public interface IShooter
    {
        public void Cast(Vector2 position);
    }
}