using UnityEngine;

public class ShooterStrategy : MonoBehaviour
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem _particleSystemPrefabs;

    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private ShotType _shotType;

    private IShooter _iShooter;
    private IShooterView _iShooterView;
    private IInput _iInput;

    private void Awake()
    {
        switch (_shotType)
        {
            case ShotType.Explosion:
                _iShooter = new ExplosionShot(_camera, _groundMask, new Raycaster(), 5, 10);
                _iShooterView = new ExplosionShotView(_particleSystemPrefabs, _iShooter);
                _iInput = new MouseInput(_camera);


                _shooter.Initialized(_iShooter, _iShooterView, _iInput);
                break;
        }
    }
}
