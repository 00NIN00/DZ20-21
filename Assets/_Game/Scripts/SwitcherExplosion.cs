using _Game.Scripts.Shooter;
using UnityEngine;

namespace _Game.Scripts
{
    public class SwitcherExplosion : MonoBehaviour
    {
        [SerializeField] private TypeExplosion _typeExplosion;

        public TypeExplosion TypeExplosion => _typeExplosion;
    }
}