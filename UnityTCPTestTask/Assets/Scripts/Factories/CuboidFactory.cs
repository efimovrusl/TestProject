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
        var obj = Instantiate( cuboidPrefab, position, Quaternion.Euler( rotation ), transform);
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
    }
    
}
}
