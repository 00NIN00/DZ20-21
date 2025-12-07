using System;
using UnityEngine;

public class Caster : MonoBehaviour
{
    private Shooter _shooter;
    private IInput _input;

    public void Initialize(IInput input)
    {
        _input = input;
        
        _shooter = new Shooter();
    }


    private void Update()
    {
        if (_input.Button1)
        {
            _shooter.Cast(_input.Position);
        }

        if (_input.ButtonHold)
        {
             _shooter.Drag(_input.Position);
        }
    }
}