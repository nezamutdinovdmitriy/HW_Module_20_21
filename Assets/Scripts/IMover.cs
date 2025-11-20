using UnityEngine;

public interface IMover
{
    public void MoveTo(Ray ray, Transform target);
}
