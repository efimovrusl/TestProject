using Factories;
using UnityEngine;
using Zenject;

namespace Installers
{
public class CuboidFactoryInstaller : MonoInstaller
{
    [SerializeField] private CuboidFactory cuboidFactory;
    
    public override void InstallBindings()
    {
        Container.Bind<CuboidFactory>().FromInstance( cuboidFactory ).AsSingle();
    }
}
}