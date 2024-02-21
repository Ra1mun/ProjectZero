using UnityEngine;
using Zenject;
using ZeroProject.Level;
using ZeroProject.Level.Room;
using ZeroProject.Level.Room.Realisation;

public class LevelInstaller : Installer<LevelInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<LevelRoot>()
            .FromComponentInNewPrefabResource("LevelRoot")
            .AsSingle();

        Container
            .Bind<RoomStorage>()
            .AsSingle();
        
        Container
            .Bind<LevelGenerator>()
            .AsSingle();

        Container
            .Bind<LevelController>()
            .AsSingle();
    }
}