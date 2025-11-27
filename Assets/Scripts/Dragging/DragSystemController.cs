using UnityEngine;

public class DragSystemController : MonoBehaviour
{
    [SerializeField] private DragSystem _dragSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _groundMask;
    
    private IInput _input;
    private PointerRayProvider _rayProvider;

    private void Awake()
    {
        _rayProvider = new PointerRayProvider(_camera);
        _input = new DesktopInput();
        _dragSystem = new DragSystem(_targetMask, _groundMask);
    }

    private void Update()
    {
        if (_input.IsDragStarted)
            _dragSystem.StartDrag(_rayProvider.Ray);

        if (_input.IsDragEnded)
            _dragSystem.EndDrag();
    }

    private void FixedUpdate()
    {
        if (_dragSystem.HasTarget())
            _dragSystem.MoveTo(_rayProvider.Ray, _dragSystem.Dragable);
    }
}
