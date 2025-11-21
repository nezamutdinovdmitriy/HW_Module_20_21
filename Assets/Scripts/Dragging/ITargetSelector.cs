using UnityEngine;

public interface ITargetSelector
{
    public Transform Target { get; }
    public bool TrySelect(Ray ray);
    public void Clear();
}
