using UnityEngine;

public class GroundRaycastMover : IMover
{
    private readonly IRaycaster _raycaster;
    private readonly LayerMask _groundMask;

    public GroundRaycastMover(IRaycaster raycaster, LayerMask groundMask, Transform target)
    {
        _raycaster = raycaster;
        _groundMask = groundMask;
    }

    public void MoveTo(Ray ray, Transform target)
    {
        if(_raycaster.Raycast(ray, _groundMask, out RaycastHit hitInfo))
            target.position = hitInfo.point;
    }
}
