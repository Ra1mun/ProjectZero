using UnityEngine;
using Zenject;
using ZeroProject.SceneStorage;

public class SceneStorageInstaller : Installer<SceneStorageInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<SceneRoot>()
            .FromComponentInNewPrefabResource("SceneRoot")
            .AsSingle();
        
        Container
            .Bind<SceneService>()
            .AsSingle();
        

        Container
            .Bind<ScenesController>()
            .AsSingle();
    }
}