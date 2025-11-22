using UnityEngine;

public class DragSystem : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _groundMask;

    private IInput _input;
    private IRaycaster _raycaster;
    private ITargetSelector _targetSelector;
    private IMover _targetMover;
    private IDragable _dragable;

    private void Awake()
    {
        _input = new MouseInput(_camera);
        _raycaster = new Raycaster();
        _targetSelector = new RaycastTargetSelector(_raycaster, _targetMask);
        _targetMover = new GroundRaycastMover(_raycaster, _groundMask);
    }

    private void Update()
    {
        if (_input.IsDown)
        {
            _targetSelector.TrySelect(_input.PointerRay);

            if (_targetSelector.Target != null)
            {
                Rigidbody targetRigidBody = _targetSelector.Target.GetComponent<Rigidbody>();

                if (targetRigidBody != null)
                {
                    _dragable = new RigidbodyDragable(targetRigidBody);
                    _dragable.Enter();
                }
            }
        }

        if (_input.IsUp)
        {
            if (_dragable != null)
            {
                _dragable.Exit();
            }
            _dragable = null;
            _targetSelector.Clear();
        }
    }

    private void FixedUpdate()
    {
        if (_targetSelector.Target != null)
            _targetMover.MoveTo(_input.PointerRay, _dragable);
    }
}
