using UnityEngine;

public interface ITargetSelector
{
    public bool TrySelect(Ray rayout, out Transform target);
}
