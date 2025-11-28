using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _cameras;

    private CameraSwitcher _switcher;
    private IInput _input;

    private void Awake()
    {
        _switcher = new CameraSwitcher(_cameras);
        _input = new DesktopInput();
    }

    private void Update()
    {
        if (_input.IsSwitchPressed)
            _switcher.SelectNextCamera();
    }
}