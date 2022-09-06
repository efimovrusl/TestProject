using System.Linq;
using Factories;
using Json;
using UnityEngine;
using Zenject;

namespace Managers
{
public class GameManager : MonoBehaviour
{
    [Inject] private TcpManager _tcpManager;
    [Inject] private UIManager _uiManager;
    [Inject] private CuboidFactory _cuboidFactory;
    [Inject] private CameraManager _cameraManager;

    private void Start()
    {
        _uiManager.OnLoadFileButtonClick += jsonPath =>
        {
            _cuboidFactory.DestroyInstances();
            
            string jsonFile = _tcpManager.ReadJsonWithTcpReader( jsonPath );
            var objects = JsonConverter.GetTransformsFromJson( jsonFile );
            if ( objects != null && objects.Count != 0 )
            {
                Debug.Log($"{objects.Count} instances are spawned!");
                foreach ( var obj in objects )
                {
                    _cuboidFactory.GetInstance( obj.p, obj.r, obj.s );
                }
            }

            Vector3[] minMax = _cuboidFactory.GetBoundsOfSpawnedObjects();
            _cameraManager.CaptureAllObjectsInAVolume( minMax[0], minMax[1] );
        };
    }
}
}
