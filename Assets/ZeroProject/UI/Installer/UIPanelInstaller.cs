using UnityEngine;
using Zenject;
using ZeroProject.UI.Realisation;

public class UIPanelInstaller : Installer<UIPanelInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<UIRoot>()
            .FromComponentInNewPrefabResource("UIRoot")
            .AsSingle();

        Container
            .Bind<UIService>()
            .AsSingle();
    }
}