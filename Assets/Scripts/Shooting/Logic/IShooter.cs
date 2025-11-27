using UnityEngine;

public interface IShooter
{
    public Vector3 HitPosition { get; }

    public void Shoot(Ray ray);
}
