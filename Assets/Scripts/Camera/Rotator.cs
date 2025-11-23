using UnityEngine;

public class Rotator : MonoBehaviour
{
    private void Update() => transform.LookAt(Camera.main.transform);
}
