using UnityEngine;

public class DragSystem
{
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
        _targetSelector.TrySelect(ray);

        if (_targetSelector.Target != null)
        {
            Dragable = _targetSelector.Target.GetComponent<IDragable>();

            if (Dragable != null)
            {
                Dragable.Enter();
            }
        }
    }

    public void EndDrag()
    {
        if (Dragable != null)
        {
            Dragable.Exit();
        }
        Dragable = null;
        _targetSelector.Clear();
    }

    public bool HasTarget() => _targetSelector.Target != null;
}
