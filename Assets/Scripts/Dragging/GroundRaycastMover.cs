using UnityEngine;

public class GroundRaycastMover : IMover
{
    private readonly IRaycaster _raycaster;
    private readonly LayerMask _groundMask;

    public GroundRaycastMover(IRaycaster raycaster, LayerMask groundMask)
    {
        _raycaster = raycaster;
        _groundMask = groundMask;
    }

    public void MoveTo(Ray ray, IDragable target)
    {
        if(_raycaster.Raycast(ray, _groundMask, out RaycastHit hitInfo))
            target.Drag(hitInfo.point);
    }
}
