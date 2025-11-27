using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private KeyCode _switchKey = KeyCode.V;
    [SerializeField] private List<CinemachineVirtualCamera> _cameras;

    private CameraSwitcher _switcher;
    private CameraInputReader _inputReader;

    private void Awake()
    {
        _switcher = new CameraSwitcher(_cameras);
        _inputReader = new CameraInputReader(_switchKey);
    }

    private void Update()
    {
        if (_inputReader.IsSwitchPressed)
            _switcher.SelectNextCamera();
    }
}
