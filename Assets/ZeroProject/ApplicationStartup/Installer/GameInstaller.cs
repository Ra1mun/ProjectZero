using UnityEngine;
using Zenject;
using ZeroProject.Room;

public class GameInstaller : Installer<GameInstaller>
{
    public override void InstallBindings()
    {
        StatsInstaller.Install(Container);
    }
}