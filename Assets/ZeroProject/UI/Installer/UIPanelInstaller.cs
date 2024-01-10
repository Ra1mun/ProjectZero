using UnityEngine;
using Zenject;
using ZeroProject.UI.Realisation;
using ZeroProject.UI.Realisation.MenuPanel;

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
        
        Container
            .Bind<MainMenuPanelController>()
            .AsSingle();
    }
}