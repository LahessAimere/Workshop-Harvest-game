using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshSurface))]
public class SpawnerOfObjects : MonoBehaviour
{
    private NavMeshSurface _meshSurface;
    private NavMeshData _navSurfaceData;
    private Vector3 _randomPointPosition;

    [SerializeField] private float _waitTimeMin;
    [SerializeField] private float _waitTimeMax;

    [SerializeField] private GameObject[] _harvestableObjects;
    private void Start()
    {
        _meshSurface = GetComponent<NavMeshSurface>();
        _navSurfaceData = _meshSurface.navMeshData;
        
        StartCoroutine(SpawnObjects());
    }

    private Vector3 RandomPoint(Bounds bounds)
   {
       float meshSurfaceX = Random.Range(bounds.min.x, bounds.max.x);
       float meshSurfaceZ = Random.Range(bounds.min.z, bounds.max.z);
        
       if (Physics.Raycast(new Vector3(meshSurfaceX, transform.position.y + 100 ,meshSurfaceZ), Vector3.down, out RaycastHit hit, Mathf.Infinity))
       {
           if (hit.collider.TryGetComponent(out NavMeshObstacle navMeshObstacle))
           {
               return RandomPoint(bounds);
           }
       }
       return new Vector3(meshSurfaceX, transform.position.y ,meshSurfaceZ);
   }

    private IEnumerator SpawnObjects()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(Random.Range(_waitTimeMin, _waitTimeMax));
            _randomPointPosition = RandomPoint(_navSurfaceData.sourceBounds);
            
            GameObject harvestableObjectPrefab = _harvestableObjects[Random.Range(0, _harvestableObjects.Length)];
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
            
            Instantiate(harvestableObjectPrefab, _randomPointPosition, randomRotation);
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(_randomPointPosition, 1);
        }
    }
}
