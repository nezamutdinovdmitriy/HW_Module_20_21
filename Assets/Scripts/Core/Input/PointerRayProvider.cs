using UnityEngine;

public class PointerRayProvider
{
    private readonly Camera _camera;

    public PointerRayProvider(Camera camera) => _camera = camera;

    public Ray Ray => _camera.ScreenPointToRay(Input.mousePosition);
}
