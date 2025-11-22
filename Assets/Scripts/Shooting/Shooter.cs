using UnityEngine;

public class Shooter : MonoBehaviour
{    
    private IShooterType _shooterType;
    private IShooterView _shooterView;
    private IInput _input;

    public void Initialized(IShooterType shooterType, IShooterView shooterView, IInput input)
    {
        _shooterType = shooterType;
        _shooterView = shooterView;
        _input = input;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _shooterType.Shoot(_input.PointerRay);
            _shooterView.PlayEffect(_shooterType.HitPosition, _shooterType.Radius);
        }
    }
}
