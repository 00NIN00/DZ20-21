using _Game.Scripts.Shooter;
using UnityEngine;
using System;

namespace _Game.Scripts
{
    public class SwitcherExplosion : MonoBehaviour
    {
        private const int Step = 1;
        
        private TypeExplosion _currentTypeExplosion;
        private TypeExplosion[] _allTypeExplosions;
        private IInput _input;
        private bool _isChange;

        public void Initialize(IInput input)
        {
            _input = input;

            _allTypeExplosions = (TypeExplosion[])Enum.GetValues(typeof(TypeExplosion));
        }

        private void Update()
        {
            if (_input.SwitchExplosionType)
            {
                Switch();
                _isChange = true;
            }
        }

        private void Switch()
        {
            int currentIndex = Array.IndexOf(_allTypeExplosions, _currentTypeExplosion);
            int newIndex = (int)Mathf.Repeat(currentIndex + Step, _allTypeExplosions.Length);
            
            _currentTypeExplosion = _allTypeExplosions[newIndex];
        }

        public bool TryGetTypeExplosion(out TypeExplosion typeExplosion)
        {
            typeExplosion = _currentTypeExplosion;
            
            if (!_isChange)
                return false;

            _isChange = false;
            return true;
        }
    }
}