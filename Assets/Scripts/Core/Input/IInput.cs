using UnityEngine;

public interface IInput
{
    public bool IsDown { get; }
    public bool IsUp { get; }
    public bool IsShot { get; }
    public Ray PointerRay { get; }
}
