using Managers;
using UnityEngine;
using Zenject;

namespace Installers
{
public class UIManagerInstaller : MonoInstaller
{
    [SerializeField] private UIManager uiManager;

    public override void InstallBindings()
    {
        Container.Bind<UIManager>().FromInstance( uiManager ).AsSingle();
    }
}
}