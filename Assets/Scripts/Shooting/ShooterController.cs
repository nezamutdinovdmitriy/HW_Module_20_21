using UnityEngine;

public class ShooterController : MonoBehaviour
{
    private PointerRayProvider _pointerRayProvider;
    private RaycastHit _raycastHit;

    private IShooter _shooter;
    private IShooterView _shooterView;
    private IInput _input;

    public void Initialize(IShooter shooter, IShooterView shooterView, IInput input, PointerRayProvider pointerRayProvider)
    {
        _shooter = shooter;
        _shooterView = shooterView;
        _input = input;
        _pointerRayProvider = pointerRayProvider;
    }

    private void Update()
    {
        if (_input.IsShot)
        {
            _shooter.Shoot(_pointerRayProvider.Ray, out _raycastHit);
            _shooterView.PlayEffect(_raycastHit.point);
        }
    }
}
