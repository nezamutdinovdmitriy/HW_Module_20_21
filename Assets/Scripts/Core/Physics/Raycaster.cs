using UnityEngine;

public class Raycaster : IRaycaster
{
    public bool Raycast(Ray ray, LayerMask mask, out RaycastHit hitInfo) => Physics.Raycast(ray, out hitInfo, Mathf.Infinity, mask);
}
