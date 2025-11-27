using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyDragable : MonoBehaviour, IDragable
{
    private Rigidbody _rigidbody;
    private bool _isKinematic;

    [SerializeField] private float _frequency = 1f;
    [SerializeField] private float _amplitude = 0.3f;
    [SerializeField] private float _startOffsetY = 1.5f;

    public Vector3 Position { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isKinematic = _rigidbody.isKinematic;
    }

    public void Enter()
    {
        if (_isKinematic == false)
            _rigidbody.isKinematic = true;
    }

    public void Exit()
    {
        if (_rigidbody.isKinematic != _isKinematic)
            _rigidbody.isKinematic = _isKinematic;
    }

    public void Drag(Vector3 position)
    {
        Position = position;

        float yOffset = _startOffsetY + Mathf.Sin(Time.time * _frequency) * _amplitude;

        position = new Vector3(position.x, position.y + yOffset, position.z);

        _rigidbody.MovePosition(position);
    }
}