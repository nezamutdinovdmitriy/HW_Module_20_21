using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Box : MonoBehaviour, IPushable
{
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Push(Vector3 direction, float force)
    {
        //Rigidbody.MovePosition(direction * force);

        Rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }
}
