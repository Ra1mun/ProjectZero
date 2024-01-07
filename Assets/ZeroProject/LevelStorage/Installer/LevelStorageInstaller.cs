using UnityEngine;
using Zenject;
using ZeroProject.LevelStorage.SceneService;
using ZeroProject.SceneStorage;

public class LevelStorageInstaller : Installer<LevelStorageInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<LevelRoot>()
            .FromComponentInNewPrefabResource("SceneRoot")
            .AsSingle();
        
        Container
            .Bind<LevelService>()
            .AsSingle();
        

        Container
            .Bind<LevelsController>()
            .AsSingle();
    }
}