using UnityEngine;

public class MouseInput : IInput
{
    private readonly Camera _camera;

    public MouseInput(Camera camera) => _camera = camera;

    public Ray PointerRay => _camera.ScreenPointToRay(Input.mousePosition);
    public bool IsDown => Input.GetMouseButtonDown(0);
    public bool IsUp => Input.GetMouseButtonUp(0);
    public bool IsShot => Input.GetMouseButtonDown(1);
}
