using System.Collections.Generic;
using UnityEngine;

namespace Factories
{
public class CuboidFactory : MonoBehaviour
{
    [SerializeField] private GameObject cuboidPrefab;

    private readonly List<GameObject> _cuboids = new List<GameObject>();

    public GameObject GetInstance( Vector3 position, Vector3 rotation, Vector3 scale )
    {
        var obj = Instantiate( cuboidPrefab, position, Quaternion.Euler( rotation ), transform );
        obj.transform.localScale = scale;
        _cuboids.Add( obj );
        return obj;
    }

    public void DestroyInstances()
    {
        foreach ( var cuboid in _cuboids )
        {
            Destroy( cuboid );
        }
        _cuboids.Clear();
    }

    public Vector3[] GetBoundsOfSpawnedObjects()
    {
        if ( _cuboids.Count == 0 ) return new[] { Vector3.zero, Vector3.one };
        Vector3 min, max;
        min = _cuboids[0].GetComponent<MeshRenderer>().bounds.min;
        max = _cuboids[0].GetComponent<MeshRenderer>().bounds.max;

        foreach ( var cuboid in _cuboids )
        {
            Vector3 minBounds = cuboid.GetComponent<MeshRenderer>().bounds.min;
            Vector3 maxBounds = cuboid.GetComponent<MeshRenderer>().bounds.max;
            if ( minBounds.x < min.x ) min.x = minBounds.x;
            if ( minBounds.y < min.y ) min.y = minBounds.y;
            if ( minBounds.z < min.z ) min.z = minBounds.z;
            if ( maxBounds.x > max.x ) max.x = maxBounds.x;
            if ( maxBounds.y > max.y ) max.y = maxBounds.y;
            if ( maxBounds.z > max.z ) max.z = maxBounds.z;
        }

        return new[] { min, max };
    }
}
}