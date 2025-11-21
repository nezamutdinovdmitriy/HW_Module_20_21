using Cinemachine.Utility;
using UnityEngine;

public class Shooter : MonoBehaviour
{    
    private IShooter _shooter;
    private IShooterView _shooterView;
    private IInput _input;

    public void Initialized(IShooter shooter, IShooterView shooterView, IInput input)
    {
        _shooter = shooter;
        _shooterView = shooterView;
        _input = input;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _shooter.Shoot(_input.PointerRay);
            _shooterView.PlayEffect(_shooter.HitPosition);
        }
    }
}
