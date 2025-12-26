using _Game.Scripts.ExplosionStrategy;
using _Game.Scripts.Shooter;
using UnityEngine;

namespace _Game.Scripts
{
    public class BootStrap : MonoBehaviour
    {
        [SerializeField] private Caster _caster;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private CameraSwitcher _cameraSwitcher;
        [SerializeField] private SwitcherExplosion  _switcherExplosion;
        
        [Header("Параметры")]
        [SerializeField] private float _radiusExplosion = 7f;
        [SerializeField] private float _forceExplosion = 5f;
    
        private void Awake()
        {
            IInput input = new InputPC();
        
            _cameraSwitcher.Initialize(input);
            _switcherExplosion.Initialize(input);
        
            _caster.Initialize(
                input,
                new Dragger(),
                new ShooterExplosion(_radiusExplosion, _particleSystem),
                _switcherExplosion, 
                new DefaultImpulse(_forceExplosion),
                new ExplosionImpulse(_forceExplosion, _radiusExplosion));
        }
    }
}