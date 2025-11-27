using UnityEngine;

public class ShooterStrategy : MonoBehaviour
{
    [SerializeField] private Shooter _shooterUser;
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem _particleSystemPrefabs;

    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private ShotType _shotType;

    private IShooterType _shooter;
    private IShooterView _shooterView;
    private IInput _input;

    private void Awake()
    {
        switch (_shotType)
        {
            case ShotType.Explosion:
                _shooter = new ExplosionShot(_camera, _groundMask, new Raycaster(), 5, 10);
                _shooterView = new ExplosionShotView(_particleSystemPrefabs);
                _input = new MouseInput(_camera);

                _shooterUser.Initialize(_shooter, _shooterView, _input);
                break;
        }
    }
}
