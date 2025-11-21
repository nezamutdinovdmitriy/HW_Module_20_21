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

    private void Awake()
    {
        switch (_shotType)
        {
            case ShotType.Explosion:
                _iShooter = new ExplosionShot(_camera, _groundMask, new MouseDragInput(_camera), new Raycaster(), 5, 10);
                _iShooterView = new ExplosionShotView(_particleSystemPrefabs, _iShooter);
                
                _shooter.Initialized(_iShooter, _iShooterView);
                break;
        }
    }
}
