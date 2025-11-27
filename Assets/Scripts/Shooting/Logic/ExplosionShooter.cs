using UnityEngine;

public class ExplosionShooter : IShooter
{
    private const float MaxMultiplier = 1f;

    private readonly float _explosionRadius;
    private readonly float _explosionForce;
    private readonly LayerMask _mask;

    private IRaycaster _raycaster;

    public ExplosionShooter(Camera camera, LayerMask groundMask, IRaycaster raycaster, float explosionRadius, float explosionForce)
    {
        _raycaster = raycaster;
        _mask = groundMask;
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
    }

    public Vector3 HitPosition { get; private set; }
    public float Radius => _explosionRadius;

    public void Shoot(Ray ray)
    {
        if (_raycaster.Raycast(ray, _mask, out RaycastHit hitInfo))
        {
            HitPosition = hitInfo.point;

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
}
