using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent _mesh;
    private Vector3 _pointPosition;
    private Camera _mainCamera;
    private Ray _ray;

    private void Start()
    {
        _mesh = GetComponent<NavMeshAgent>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(_ray.origin, _ray.direction, Color.red);
            
            bool isHit = Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity);
            
            if (isHit)
            {
                _pointPosition = hit.point;
                _mesh.SetDestination(hit.point);
            }
        }
    }
    
    void OnDrawGizmos()
    {
        _mesh = GetComponent<NavMeshAgent>();
        
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_mesh.destination, 1);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_pointPosition, 1);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(_ray);
    }
}
