using UnityEngine;
using Zenject;
using ZeroProject.Level;

public class LevelInstaller : Installer<LevelInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<LevelRoot>()
            .FromComponentInNewPrefabResource("LevelRoot")
            .AsSingle();
        
        Container
            .Bind<LevelGenerator>()
            .AsSingle();
        
        Container
            .Bind<LevelBuilder>()
            .AsSingle();
        
    }
}