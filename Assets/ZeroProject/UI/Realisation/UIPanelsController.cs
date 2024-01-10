using System;
using System.Collections.Generic;
using ZeroProject.SceneStorage.Interfaces;
using ZeroProject.UI.Interfaces;
using ZeroProject.UI.Realisation.MenuPanel;

namespace ZeroProject.UI.Realisation
{
    public class UIPanelsController
    {
        private LinkedList<IUIPanelController> _panelControllers = new LinkedList<IUIPanelController>();

        public UIPanelsController(
            DevelopmentSettings developmentSettings,
            MainMenuPanelController mainMenuPanelController)
        {
            switch (developmentSettings.UIType)
            {
                case UIType.MainMenu:
                    SetupPanel(mainMenuPanelController);
                    break;
                case UIType.Game:
                    break;
                default:
                    throw new ApplicationException($"That type of UI {developmentSettings.UIType} did not found");
            }
        }

        public void ShowFirstPanel()
        {
            _panelControllers.First?.Value.ShowPanel();
        }

        private void SetupPanel(IUIPanelController uiPanelController)
        {
            _panelControllers.AddLast(uiPanelController);
        }
    }
}