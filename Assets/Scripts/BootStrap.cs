using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private Caster _caster;
    
    private void Awake()
    {
        _caster.Initialize(new InputPC());
    }
}