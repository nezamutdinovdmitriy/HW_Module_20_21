using Cinemachine;
using System.Collections.Generic;

public class CameraSwitcher
{
    private Queue<CinemachineVirtualCamera> _camerasQueue = new();
    private CinemachineVirtualCamera _currentCamera;

    public CameraSwitcher(List<CinemachineVirtualCamera> _camerasList)
    {
        foreach (CinemachineVirtualCamera camera in _camerasList)
            _camerasQueue.Enqueue(camera);

        SelectNextCamera();
    }

    public void SelectNextCamera()
    {
        _currentCamera = _camerasQueue.Dequeue();
        _camerasQueue.Enqueue(_currentCamera);

        foreach (CinemachineVirtualCamera camera in _camerasQueue)
        {
            camera.enabled = (camera == _currentCamera);
        }
    }
}
