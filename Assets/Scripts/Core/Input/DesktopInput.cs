using UnityEngine;

public class DesktopInput : IInput
{
    public bool IsDragStarted => Input.GetMouseButtonDown(0);
    public bool IsDragEnded => Input.GetMouseButtonUp(0);
    public bool IsShot => Input.GetMouseButtonDown(1);
    public bool IsSwitchPressed => Input.GetKeyDown(KeyCode.V);
}
