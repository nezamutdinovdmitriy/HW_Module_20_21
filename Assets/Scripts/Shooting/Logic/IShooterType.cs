using UnityEngine;

public interface IShooterType
{
    public Vector3 HitPosition { get; }

    public float Radius { get; }

    public void Shoot(Ray ray);
}
