using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using ZeroProject.Bootstrap.Interfaces;
using ZeroProject.Level;
using ZeroProject.Level.Room;
using ZeroProject.UI.Realisation;
using ZeroProject.UI.Realisation.MenuPanel;

namespace ZeroProject.ApplicationStartup.Realisation
{
    public class InitApplicationCommand : ICommand
    {
        private readonly UIPanelsController _uiPanelsController;
        private readonly DevelopmentSettings _developmentSettings;
        private readonly LevelController _levelController;
        private readonly RoomStorage _roomStorage;

        public Action Done { get; set; }

        public InitApplicationCommand(
            UIPanelsController uiPanelsController,
            DevelopmentSettings developmentSettings,
            LevelController levelController,
            RoomStorage roomStorage)
        {
            _uiPanelsController = uiPanelsController;
            _developmentSettings = developmentSettings;
            _levelController = levelController;
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
                    _roomStorage.LoadRooms("TestLevel");
                    _levelController.LoadLevel();
                    _levelController.ShowFirstRoom();
                    break;
                default:
                    throw new NotImplementedException("Scene not found!");
            }

            Done?.Invoke();
        }
    }
}
