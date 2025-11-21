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

    public Transform Target { get; private set; }

    public void Clear() => Target = null;

    public bool TrySelect(Ray ray)
    {
        if(_raycaster.Raycast(ray, _mask, out RaycastHit hitInfo))
        {
            Target = hitInfo.transform;
            return true;
        }

        return false;
    }
}
