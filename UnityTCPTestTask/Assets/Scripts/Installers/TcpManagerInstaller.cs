using Managers;
using UnityEngine;
using Zenject;

namespace Installers
{
public class TcpManagerInstaller : MonoInstaller
{
    [SerializeField] private TcpManager tcpManager;

    public override void InstallBindings()
    {
        Container.Bind<TcpManager>().FromInstance( tcpManager ).AsSingle();
    }
}
}