using UnityEngine;
using Zenject;

public class CameraManagerInstaller : MonoInstaller
{
    [SerializeField] private CameraManager _cameraManager;
    
    public override void InstallBindings()
    {
        Container.Bind<CameraManager>().FromInstance( _cameraManager ).AsSingle();
    }
}