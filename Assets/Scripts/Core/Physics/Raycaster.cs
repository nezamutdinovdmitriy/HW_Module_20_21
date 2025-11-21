using UnityEngine;

public class Raycaster : IRaycaster
{
    public bool Raycast(Ray ray, LayerMask mask, out RaycastHit hitInfo)
    {
        return Physics.Raycast(ray, out hitInfo, Mathf.Infinity, mask);
    }
}
