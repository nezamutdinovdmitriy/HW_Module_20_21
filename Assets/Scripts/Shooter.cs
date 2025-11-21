using Cinemachine.Utility;
using UnityEngine;

public class Shooter : MonoBehaviour
{    
    private IShooter _shooter;
    private IShooterView _shooterView;

    public void Initialized(IShooter shooter, IShooterView shooterView)
    {
        _shooter = shooter;
        _shooterView = shooterView;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
            _shooter.Shoot();

        if (_shooter.IsShot)
        {
            Instantiate(_shooterView.ParticleSystem, _shooter.HitPosition, Quaternion.identity);
            _shooterView.ShowEffect();
        }
    }
}
