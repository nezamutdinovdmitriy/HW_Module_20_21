using UnityEngine;

public interface IMover
{
    public void MoveTo(Ray ray, IDragable target);
}
