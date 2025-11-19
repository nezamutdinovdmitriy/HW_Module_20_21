using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _layerMask;

    private Transform _target;
    private Rigidbody _targetRigidbody;


    private void Update()
    {
        Vector3 screenMousePosition = Input.mousePosition;
        Ray worldMouseRay = _camera.ScreenPointToRay(screenMousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(worldMouseRay, out RaycastHit hitInfo, Mathf.Infinity, _layerMask))
            {
                _target = hitInfo.collider.gameObject.transform;

                _targetRigidbody = _target.GetComponent<Rigidbody>();
                _targetRigidbody.isKinematic = true;

                Debug.Log(hitInfo.collider.name);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _target = null;
            _targetRigidbody.isKinematic = false;
        }

        if (_target != null)
        {
            float distanceToTarget = Vector3.Distance(_camera.transform.position, _target.transform.position);
            screenMousePosition.z = distanceToTarget;

            Vector3 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition);

            _target.position = new Vector3(worldMousePosition.x, _target.position.y, worldMousePosition.z);
            
            if (_target.position.y < 0)
                _target.position = new Vector3(_target.position.x, 0, _target.position.z);
        }
    }
}
