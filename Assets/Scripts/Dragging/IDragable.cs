using UnityEngine;

public interface IDragable
{
    public void Enter();
    public void Drag(Vector3 position);
    public void Exit();
}
