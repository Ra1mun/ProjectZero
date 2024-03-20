using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using ZeroProject.Bootstrap.Interfaces;
using ZeroProject.Level;
using ZeroProject.Level.Room;
using ZeroProject.Level.Room.Realisation;
using ZeroProject.UI.Realisation;
using ZeroProject.UI.Realisation.MenuPanel;

namespace ZeroProject.ApplicationStartup.Realisation
{
    public class InitApplicationCommand : ICommand
    {
        private readonly UIPanelsController _uiPanelsController;
        private readonly DevelopmentSettings _developmentSettings;
        private readonly LevelService _levelService;
        private readonly RoomStorage _roomStorage;
        private readonly RoomsController _roomsController;

        public Action Done { get; set; }

        public InitApplicationCommand(
            UIPanelsController uiPanelsController,
            DevelopmentSettings developmentSettings,
            LevelService levelService,
            RoomStorage roomStorage,
            RoomsController roomsController)
        {
            _uiPanelsController = uiPanelsController;
            _developmentSettings = developmentSettings;
            _levelService = levelService;
            _roomStorage = roomStorage;
            _roomsController = roomsController;
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
                    _levelService.InitLevel();
                    _roomsController.ShowFirstRoom();
                    break;
                default:
                    throw new NotImplementedException("Scene not found!");
            }

            Done?.Invoke();
        }
    }
}
