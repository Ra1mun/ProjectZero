using System;
using Unity.VisualScripting;
using ZeroProject.Bootstrap.Interfaces;
using ZeroProject.Level;
using ZeroProject.Room;
using ZeroProject.UI.Realisation;
using ZeroProject.UI.Realisation.MenuPanel;

namespace ZeroProject.ApplicationStartup.Realisation
{
    public class InitApplicationCommand : ICommand
    {
        private readonly UIPanelsController _uiPanelsController;
        private readonly DevelopmentSettings _developmentSettings;
        private readonly LevelBuilder _levelBuilder;
        private readonly RoomStorage _roomStorage;

        public Action Done { get; set; }

        public InitApplicationCommand(
            UIPanelsController uiPanelsController,
            DevelopmentSettings developmentSettings,
            LevelBuilder levelBuilder,
            RoomStorage roomStorage)
        {
            _uiPanelsController = uiPanelsController;
            _developmentSettings = developmentSettings;
            _levelBuilder = levelBuilder;
            _roomStorage = roomStorage;
        }
    
        public void Execute()
        {
            switch (_developmentSettings.SceneType)
            {
                case SceneType.MainMenu:
                    _uiPanelsController.ShowPanel<MainMenuPanelController>();
                    break;
                case SceneType.Game:
                    _levelBuilder.ShowFirstRoom();
                    break;
                default:
                    throw new NotImplementedException("Panels not found!");
            }

            Done?.Invoke();
        }
    }
}
