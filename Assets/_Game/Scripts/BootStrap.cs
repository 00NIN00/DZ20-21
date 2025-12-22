using _Game.Scripts.Shooter;
using UnityEngine;

namespace _Game.Scripts
{
    public class BootStrap : MonoBehaviour
    {
        [SerializeField] private Caster _caster;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private CameraSwitcher _cameraSwitcher;
    
        private void Awake()
        {
            IInput input = new InputPC();
        
            _caster.Initialize(input, new ShooterDrag(), new ShooterExplosion(7f, 3f, _particleSystem));
        
            _cameraSwitcher.Initialize(input);
        }
    }
}