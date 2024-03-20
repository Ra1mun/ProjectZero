using UnityEngine;
using Zenject;
using ZeroProject.ApplicationStartup.Realisation;
using System;
using ZeroProject.UI.Realisation;
using ZeroProject.SceneObject.Realisation;

public class ApplicationInstaller : MonoInstaller
{
    [SerializeField] private SceneType sceneType;
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    public override void InstallBindings()
    {
        var developmentSettings = new DevelopmentSettings(
            sceneType);
        
        Container
            .Bind<DevelopmentSettings>()
            .FromInstance(developmentSettings)
            .AsSingle();
        
        switch (sceneType)
        {
            case SceneType.MainMenu:
                MainMenuInstaller.Install(Container); 
                break;
            case SceneType.Game:
                GameInstaller.Install(Container);
                break;
            default:
                throw new NotImplementedException($"Installer with type { sceneType } not create!");
        }

        UIPanelInstaller.Install(Container);

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
    public readonly SceneType SceneType;
    public readonly float JumpForce;
    public readonly float MoveSpeed;
    public DevelopmentSettings(SceneType uiType,
        float jumpForce,
        float moveSpeed)
    {
        SceneType = uiType;
        JumpForce = jumpForce;
        MoveSpeed = moveSpeed;
    }
}