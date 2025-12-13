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
        /*if (_input.Button1)
        {
            _shooter.Cast(_input.Position);
        }
        else */if(_input.Button1Hold)
        {
            _shooter.Cast(_input.Position);
             //_shooter.Drag(_input.Position);
        }
    }
}