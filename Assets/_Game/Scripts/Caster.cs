using _Game.Scripts.ExplosionStrategy;
using _Game.Scripts.Shooter;
using UnityEngine;

namespace _Game.Scripts
{
    public class Caster : MonoBehaviour
    {
        private IInput _input;
    
        private Dragger _dragger;
        private ShooterExplosion _shooterExplosion;

        private SwitcherExplosion _switcherExplosion;

        private DefaultImpulse  _defaultImpulse;
        private ExplosionImpulse  _explosionImpulse;
        
        public void Initialize(
            IInput input,
            Dragger dragger,
            ShooterExplosion shooterExplosion,
            SwitcherExplosion switcherExplosion,
            DefaultImpulse defaultImpulse,
            ExplosionImpulse explosionImpulse)
        {
            _input = input;
        
            _dragger = dragger;
            _shooterExplosion = shooterExplosion;
            _switcherExplosion = switcherExplosion;
            
            _defaultImpulse = defaultImpulse;
            _explosionImpulse = explosionImpulse;
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

            if (_switcherExplosion.TryGetTypeExplosion(out TypeExplosion typeExplosion))
            {
                _shooterExplosion.SetExplosionType(GetExplosionType(typeExplosion));
            }
        }
        
        private IExplosion GetExplosionType(TypeExplosion typeExplosion)
        {
            switch (typeExplosion)
            {
                case TypeExplosion.DefaultImpulse:
                    return _defaultImpulse;
                
                case TypeExplosion.ExplosionImpulse:
                    return _explosionImpulse;
                
                default:
                    return null;
            }
        }
    }
}