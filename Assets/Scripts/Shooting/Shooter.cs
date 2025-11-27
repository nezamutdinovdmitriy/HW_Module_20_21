using UnityEngine;

public class Shooter : MonoBehaviour
{    
    private IShooterType _shooterType;
    private IShooterView _shooterView;
    private IInput _input;

    public void Initialize(IShooterType shooterType, IShooterView shooterView, IInput input)
    {
        _shooterType = shooterType;
        _shooterView = shooterView;
        _input = input;
    }

    private void Update()
    {
        if (_input.IsShot)
        {
            _shooterType.Shoot(_input.PointerRay);
            _shooterView.PlayEffect(_shooterType.HitPosition, _shooterType.Radius);
        }
    }
}
