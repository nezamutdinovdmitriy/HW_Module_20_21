using UnityEngine;

public interface IPushable
{
    public Rigidbody Rigidbody { get; }

    public void Push(Vector3 direction, float force);
}