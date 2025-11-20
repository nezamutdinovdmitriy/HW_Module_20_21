using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _targetObjectMask;
    [SerializeField] private LayerMask _groundMask;

    private Transform _target;

    private void Update()
    {
        Vector3 screenMousePosition = Input.mousePosition;
        Ray worldMouseRay = _camera.ScreenPointToRay(screenMousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(worldMouseRay, out RaycastHit hitInfo, Mathf.Infinity, _targetObjectMask))
            {
                _target = hitInfo.collider.gameObject.transform;

                Debug.Log(hitInfo.collider.name);
            }
        }

        if (Input.GetMouseButtonUp(0))
            _target = null;

        if (_target != null)
        {
            if(Physics.Raycast(worldMouseRay, out RaycastHit hitInfo, Mathf.Infinity, _groundMask))
                _target.position = hitInfo.point;
        }
    }
}
