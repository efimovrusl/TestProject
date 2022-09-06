using Factories;
using UnityEngine;
using Zenject;

namespace Managers
{
public class GameManager : MonoBehaviour
{
    [Inject] private TcpManager _tcpManager;
    [Inject] private UIManager _uiManager;
    [Inject] private CuboidFactory _cuboidFactory;

    private void Start()
    {
        _uiManager.OnLoadFileButtonClick += jsonPath =>
        {
            string jsonString = _tcpManager.ReadJsonWithTcpReader( jsonPath );
            Debug.Log( jsonPath );
        };
    }
}
}
