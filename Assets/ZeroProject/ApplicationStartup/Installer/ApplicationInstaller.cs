using UnityEngine;
using Zenject;
using ZeroProject.ApplicationStartup.Realisation;
using ZeroProject.SceneObject.Realisation;
using ZeroProject.UI.Realisation;

public class ApplicationInstaller : MonoInstaller
{
    [SerializeField] private UIType uiType;
    public override void InstallBindings()
    {
        var developmentSettings = new DevelopmentSettings(uiType);
        
        Container
            .Bind<DevelopmentSettings>()
            .FromInstance(developmentSettings)
            .AsSingle();
        
        if (uiType == UIType.Game)
        {
            LevelStorageInstaller.Install(Container);
        }
        
        UIPanelInstaller.Install(Container);
        
        StatsInstaller.Install(Container);

        Container
            .Bind<SceneObjectStorage>()
            .AsSingle();
        
        Container
            .Bind<ApplicationStartup>()
            .AsSingle()
            .NonLazy();
    }
}

public class DevelopmentSettings
{
    public readonly UIType UIType;
    public DevelopmentSettings(UIType uiType)
    {
        UIType = uiType;
    }
}