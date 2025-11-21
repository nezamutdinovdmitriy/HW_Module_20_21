using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _camerasList;

    private Queue<CinemachineVirtualCamera> _camerasQueue = new();
    private CinemachineVirtualCamera _currentCamera;

    private void Awake()
    {
        foreach (CinemachineVirtualCamera camera in _camerasList)
            _camerasQueue.Enqueue(camera);

        UpdateCamera();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            UpdateCamera();
    }

    private void UpdateCamera()
    {
        _currentCamera = _camerasQueue.Dequeue();
        _camerasQueue.Enqueue(_currentCamera);

        foreach (CinemachineVirtualCamera camera in _camerasQueue)
        {
            camera.enabled = (camera == _currentCamera);
        }
    }
}
