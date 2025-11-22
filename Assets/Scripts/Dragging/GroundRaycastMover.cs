using UnityEngine;

public class GroundRaycastMover : IMover
{
    private readonly IRaycaster _raycaster;
    private readonly LayerMask _groundMask;

    private readonly float _frequency = 1f;
    private readonly float _amplitude = 0.3f;
    private readonly float _startOffsetY = 1.5f;

    public GroundRaycastMover(IRaycaster raycaster, LayerMask groundMask)
    {
        _raycaster = raycaster;
        _groundMask = groundMask;
    }

    public void MoveTo(Ray ray, Transform target)
    {
        if(_raycaster.Raycast(ray, _groundMask, out RaycastHit hitInfo))
        {
            if(target.TryGetComponent<Rigidbody>(out Rigidbody targetRigidbody))
                targetRigidbody.isKinematic = true;

            target.position = hitInfo.point;

            float yOffset = _startOffsetY + Mathf.Sin(Time.time * _frequency) * _amplitude;

            target.position = new Vector3(target.position.x, target.position.y + yOffset, target.position.z);
        }
    }
}
