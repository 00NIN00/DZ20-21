using _Game.Scripts;
using _Game.Scripts.Shooter;
using UnityEngine;

public class Caster : MonoBehaviour
{
    private IInput _input;
    
    private ShooterDrag _shooterDrag;
    private ShooterExplosion _shooterExplosion;

    public void Initialize(IInput input, ShooterDrag shooterDrag, ShooterExplosion shooterExplosion)
    {
        _input = input;
        
        _shooterDrag = shooterDrag;
        _shooterExplosion = shooterExplosion;
    }
    
    private void Update()
    {
        if (_input.Button1)
        {
            _shooterDrag.Cast(_input.Position);    
        }
        
        if(_input.Button1Hold)
        {
            _shooterDrag.Drag(_input.Position);
        }
        else if(_input.Button1Hold == false)
        {
            _shooterDrag.Release();
        }

        if (_input.Button2)
        {
            _shooterExplosion.Cast(_input.Position);
        }
    }
}