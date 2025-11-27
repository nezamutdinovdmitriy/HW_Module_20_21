using UnityEngine;

public class CameraInputReader
{
    private readonly KeyCode _switchKey;

    public CameraInputReader(KeyCode switchKey)
    {
        _switchKey = switchKey;
    }

    public bool IsSwitchPressed => Input.GetKeyDown(_switchKey);
}
