using _Game.Scripts.Shooter;
using UnityEngine;

namespace _Game.Scripts
{
    public class Caster : MonoBehaviour
    {
        private IInput _input;
    
        private Dragger _dragger;
        private ShooterExplosion _shooterExplosion;

        public void Initialize(IInput input, Dragger dragger, ShooterExplosion shooterExplosion)
        {
            _input = input;
        
            _dragger = dragger;
            _shooterExplosion = shooterExplosion;
        }
    
        private void Update()
        {
            if (_input.Button1)
            {
                _dragger.Cast(_input.Position);    
            }
        
            if(_input.Button1Hold)
            {
                _dragger.Drag(_input.Position);
            }
            else if(_input.Button1Hold == false)
            {
                _dragger.Release();
            }

            if (_input.Button2)
            {
                _shooterExplosion.Cast(_input.Position);
            }
        }
    }
}