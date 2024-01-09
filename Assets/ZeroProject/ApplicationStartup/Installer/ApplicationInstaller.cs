using UnityEngine;
using Zenject;
using ZeroProject.ApplicationStartup.Realisation;

public class ApplicationInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<ApplicationStartup>()
            .AsSingle();
    }
}

public class DevelopmentSettings
{
    public DevelopmentSettings()
    {
        
    }
}