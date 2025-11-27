using UnityEngine;

public interface IInput
{
    public bool IsDragStarted { get; }
    public bool IsDragEnded { get; }
    public bool IsShot { get; }
    public bool IsSwitchPressed { get; }
}
