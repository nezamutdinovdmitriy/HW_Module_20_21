using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyPushable : MonoBehaviour, IPushable
{
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Push(Vector3 direction, float force)
    {
        Rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }
}