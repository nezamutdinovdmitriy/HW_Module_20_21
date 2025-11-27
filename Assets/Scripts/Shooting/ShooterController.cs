using UnityEngine;

public class ShooterController : MonoBehaviour
{    
    private IShooter _shooterType;
    private IShooterView _shooterView;
    private IInput _input;
    private PointerRayProvider _pointerRayProvider;

    public void Initialize(IShooter shooterType, IShooterView shooterView, IInput input, PointerRayProvider pointerRayProvider)
    {
        _shooterType = shooterType;
        _shooterView = shooterView;
        _input = input;
        _pointerRayProvider = pointerRayProvider;
    }

    private void Update()
    {
        if (_input.IsShot)
        {
            _shooterType.Shoot(_pointerRayProvider.Ray);
            _shooterView.PlayEffect(_shooterType.HitPosition, );
        }
    }
}
