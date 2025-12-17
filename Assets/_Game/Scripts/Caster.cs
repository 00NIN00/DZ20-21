using _Game.Scripts;
using UnityEngine;

public class Caster : MonoBehaviour
{
    private IShooter _shooter;
    private IInput _input;
    private ParticleSystem _particleSystem;

    public void Initialize(IInput input, ParticleSystem particleSystem)
    {
        _input = input;
        _particleSystem = particleSystem;
    }

    public void SetShooter(IShooter shooter)
    {
        if (_shooter != shooter)
            _shooter = shooter;
    }


    private void Update()
    {
        if(_input.Button1Hold)
        {
            SetShooter(new ShooterDrag());
            _shooter.Cast(_input.Position);
        }

        if (_input.Button2)
        {
            SetShooter(new ShooterExplosion(7, 3, _particleSystem));
            _shooter.Cast(_input.Position);
        }
    }
}