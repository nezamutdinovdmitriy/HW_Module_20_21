using UnityEngine;

public class DragSystem
{
    private Transform _target;
    private LayerMask _groundMask;

    private IRaycaster _raycaster;
    private ITargetSelector _targetSelector;

    public DragSystem(LayerMask targetMask, LayerMask groundMask)
    {
        _raycaster = new Raycaster();
        _targetSelector = new RaycastTargetSelector(_raycaster, targetMask);
        _groundMask = groundMask;
    }

    public IDragable Dragable {  get; private set; }

    public void MoveTo(Ray ray, IDragable target)
    {
        if (_raycaster.Raycast(ray, _groundMask, out RaycastHit hitInfo))
            target.Drag(hitInfo.point);
    }

    public void StartDrag(Ray ray)
    {
        if(_targetSelector.TrySelect(ray, out _target))
        {
            Dragable = _target.GetComponent<IDragable>();

            if (Dragable != null)
                Dragable.Enter();
        }
    }

    public void EndDrag()
    {
        if (Dragable != null)
            Dragable.Exit();

        Dragable = null;
    }

    public bool HasTarget() => Dragable != null;
}
