using UnityEngine;

public class DragSystem : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _groundMask;

    private IDragInput _input;
    private IRaycaster _raycaster;
    private ITargetSelector _targetSelector;
    private IMover _targetMover;

    private void Awake()
    {
        _input = new MouseDragInput(_camera);
        _raycaster = new Raycaster();
        _targetSelector = new RaycastTargetSelector(_raycaster, _targetMask);
        _targetMover = new GroundRaycastMover(_raycaster, _groundMask);
    }

    private void Update()
    {
        if (_input.IsDown)
            _targetSelector.TrySelect(_input.PointerRay);

        if (_input.IsUp)
            _targetSelector.Clear();

        if (_targetSelector.Target != null)
            _targetMover.MoveTo(_input.PointerRay, _targetSelector.Target);
    }
}
