using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private Caster _caster;
    [SerializeField] private ParticleSystem _particleSystem;
    
    private void Awake()
    {
        _caster.Initialize(new InputPC(), _particleSystem);
        _caster.SetShooter(new ShooterExplosion(7f, 3f, _particleSystem));
    }
}