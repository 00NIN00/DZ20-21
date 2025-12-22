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
    
        private void Awake()
        {
            IInput input = new InputPC();
        
            _caster.Initialize(input, new Dragger(), new ShooterExplosion(7f, 3f, _particleSystem, _switcherExplosion));
        
            _cameraSwitcher.Initialize(input);
        }
    }
}