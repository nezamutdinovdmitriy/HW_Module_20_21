using UnityEngine;

public interface IShooter
{
    public Vector3 HitPosition { get; }
    public bool IsShot { get;}
    
    public void Shoot();
    public void ResetShot();
}
