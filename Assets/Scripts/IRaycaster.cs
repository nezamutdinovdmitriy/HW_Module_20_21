using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRaycaster
{
    public bool Raycast(Ray ray, LayerMask layerMask, out RaycastHit hitInfo);
}
