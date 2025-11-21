using UnityEngine;

public class ExplosionShot : IShooter
{
    private const float MaxMultiplier = 1f;

    private readonly float _explosionRadius;
    private readonly float _explosionForce;
    private readonly LayerMask _mask;

    private IDragInput _input;
    private IRaycaster _raycaster;
    
    public Vector3 HitPosition { get; private set; }

    public bool IsShot { get; private set; }

    public ExplosionShot(Camera camera, LayerMask groundMask, IDragInput input, IRaycaster raycaster, float explosionRadius, float explosionForce)
    {
        _input = input;
        _raycaster = raycaster;
        _mask = groundMask;
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
    }

    public void Shoot()
    {
        if (_raycaster.Raycast(_input.PointerRay, _mask, out RaycastHit hitInfo))
        {
            HitPosition = hitInfo.point;

            if (HitPosition != Vector3.zero)
                IsShot = true;

            Collider[] targets = Physics.OverlapSphere(hitInfo.point, _explosionRadius);

            foreach (Collider target in targets)
            {
                if (target.TryGetComponent<IPushable>(out IPushable pushableTarget))
                {
                    Vector3 direction = (target.transform.position - hitInfo.point).normalized;

                    float distance = Vector3.Distance(target.transform.position, HitPosition);

                    float multiplier = MaxMultiplier - Mathf.Clamp01(distance / _explosionRadius);

                    pushableTarget.Push(direction, _explosionForce * multiplier);
                }
            }
        }
    }

    public void ResetShot() => IsShot = false;
}
