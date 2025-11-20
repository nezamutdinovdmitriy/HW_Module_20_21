using UnityEngine;

public interface IDragInput
{
    public bool IsDown { get; }
    public bool IsUp { get; }
    public Ray PointerRay { get; }
}
