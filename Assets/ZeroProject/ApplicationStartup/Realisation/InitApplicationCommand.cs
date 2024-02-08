using System;
using Unity.VisualScripting;
using ZeroProject.Bootstrap.Interfaces;
using ZeroProject.UI.Realisation;
using ZeroProject.UI.Realisation.MenuPanel;

namespace ZeroProject.ApplicationStartup.Realisation
{
    public class InitApplicationCommand : ICommand
    {
        private readonly UIPanelsController _uiPanelsController;
        private readonly DevelopmentSettings _developmentSettings;

        public Action Done { get; set; }

        public InitApplicationCommand(UIPanelsController uiPanelsController,
            DevelopmentSettings developmentSettings)
        {
            _uiPanelsController = uiPanelsController;
            _developmentSettings = developmentSettings;
        }
    
        public void Execute()
        {
            switch (_developmentSettings.SceneType)
            {
                case SceneType.MainMenu:
                    _uiPanelsController.ShowPanel<MainMenuPanelController>();
                    break;
                case SceneType.Game:
                    break;
                default:
                    throw new NotImplementedException("Panels not found!");
            }

            Done?.Invoke();
        }
    }
}
