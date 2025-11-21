using UnityEngine;

public interface IRaycaster
{
    public bool Raycast(Ray ray, LayerMask layerMask, out RaycastHit hitInfo);
}
