using UnityEngine;

public class RigidbodyDragable : IDragable
{
    private Rigidbody _rigidbody;

    public Vector3 Position { get; private set; }

    public RigidbodyDragable(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }

    public void Enter()
    {
        _rigidbody.isKinematic = true;
    }

    public void Exit()
    {
        _rigidbody.isKinematic = false;
    }

    public void Drag(Vector3 position)
    {
        Position = position;

        _rigidbody.MovePosition(position);
    }
}
