using UnityEngine;
using Zenject;
using ZeroProject.Room;

public class GameInstaller : Installer<GameInstaller>
{
    public override void InstallBindings()
    {
        LevelInstaller.Install(Container);
        
        StatsInstaller.Install(Container);
    }
}