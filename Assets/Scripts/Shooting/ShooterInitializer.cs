using UnityEngine;

public class ShooterInitializer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private ShooterController _shooterUser;
    [SerializeField] private ParticleSystem _particleSystemPrefabs;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _radius;

    private IShooter _shooter;
    private IShooterView _shooterView;
    private IInput _input;
    private PointerRayProvider _pointerRayProvider;

    private void Awake()
    {
        _shooter = new ExplosionShooter(_camera, _groundMask, new Raycaster(), _radius, 10);
        _shooterView = new ExplosionShooterView(_particleSystemPrefabs, _radius);
        _input = new DesktopInput();
        _pointerRayProvider = new PointerRayProvider(_camera);

        _shooterUser.Initialize(_shooter, _shooterView, _input, _pointerRayProvider);
    }
}
