using UnityEngine;

public class MouseDragInput : IDragInput
{
    private readonly Camera _camera;
    
    public MouseDragInput(Camera camera) => _camera = camera;

    public bool IsDown => Input.GetMouseButtonDown(0);

    public bool IsUp => Input.GetMouseButtonUp(0);

    public Ray PointerRay => _camera.ScreenPointToRay(Input.mousePosition);
}
