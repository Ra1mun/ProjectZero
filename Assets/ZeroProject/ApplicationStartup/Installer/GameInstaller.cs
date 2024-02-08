using UnityEngine;
using Zenject;

public class GameInstaller : Installer<GameInstaller>
{
    public override void InstallBindings()
    {
        StatsInstaller.Install(Container);
    }
}