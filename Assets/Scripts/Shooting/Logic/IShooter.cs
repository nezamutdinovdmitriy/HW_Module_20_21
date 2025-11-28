using UnityEngine;

public interface IShooter
{
    public void Shoot(Ray ray, out RaycastHit hit);
}
