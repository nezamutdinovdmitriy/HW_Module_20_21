using UnityEngine;

public class RaycastTargetSelector : ITargetSelector
{
    private readonly IRaycaster _raycaster;
    private readonly LayerMask _mask;

    public RaycastTargetSelector(IRaycaster raycaster, LayerMask mask)
    {
        _raycaster = raycaster;
        _mask = mask;
    }

    public bool TrySelect(Ray ray, out Transform target)
    {
        if(_raycaster.Raycast(ray, _mask, out RaycastHit hitInfo))
        {
            target = hitInfo.transform;
            return true;
        }

        target = null;
        return false;
    }
}
