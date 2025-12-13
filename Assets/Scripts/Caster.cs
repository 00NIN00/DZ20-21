using UnityEngine;

public class Caster : MonoBehaviour
{
    private IShooter _shooter;
    private IInput _input;

    public void Initialize(IInput input)
    {
        _input = input;
    }

    public void SetShooter(IShooter shooter)
    {
        if (_shooter != shooter)
            _shooter = shooter;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetShooter(new ShooterDrag());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetShooter(new ShooterExplosion(7, 3));
        }
        if(_input.Button1Hold)
        {
            _shooter.Cast(_input.Position);
        }

        if (_input.Button2)
        {
            _shooter.Cast(_input.Position);
        }
    }
}