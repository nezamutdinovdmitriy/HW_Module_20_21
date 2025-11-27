using UnityEngine;

public class ShooterStrategy : MonoBehaviour
{
    [SerializeField] private ShooterController _shooterUser;
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem _particleSystemPrefabs;

    [SerializeField] private LayerMask _groundMask;

    private IShooter _shooter;
    private IShooterView _shooterView;
    private IInput _input;
    private PointerRayProvider _pointerRayProvider;

    private void Awake()
    {
        _shooter = new ExplosionShooter(_camera, _groundMask, new Raycaster(), 5, 10);
        _shooterView = new ExplosionShotView(_particleSystemPrefabs, _shooter);
        _input = new DesktopInput();
        _pointerRayProvider = new PointerRayProvider(_camera);

        _shooterUser.Initialize(_shooter, _shooterView, _input, _pointerRayProvider);
    }
}
