using UnityEngine;

public class MouseInput : IInput
{
    private readonly Camera _camera;
    
    public MouseInput(Camera camera) => _camera = camera;

    public bool IsDown => Input.GetMouseButtonDown(0);

    public bool IsUp => Input.GetMouseButtonUp(0);

    public bool IsShot => Input.GetMouseButtonUp(1);

    public Ray PointerRay => _camera.ScreenPointToRay(Input.mousePosition);
}
