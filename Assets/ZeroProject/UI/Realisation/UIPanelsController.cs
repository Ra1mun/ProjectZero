using System;
using System.Collections.Generic;
using UnityEngine;
using ZeroProject.UI.Interfaces;
using ZeroProject.UI.Realisation.MenuPanel;

namespace ZeroProject.UI.Realisation
{
    public class UIPanelsController
    {
        private readonly Dictionary<Type, IUIPanelController> _uiPanelControllers = new Dictionary<Type, IUIPanelController>();

        public UIPanelsController(
            DevelopmentSettings developmentSettings,
            MainMenuPanelController mainMenuPanelController)
        {
            switch (developmentSettings.SceneType)
            {
                case SceneType.MainMenu:
                    SetupPanel(mainMenuPanelController);
                    break;
                case SceneType.Game:
                    break;
            }
        }

        public void ShowPanel<T>() where T: IUIPanelController
        {
            var type = typeof(T);
            if (_uiPanelControllers.ContainsKey(type))
            {
                _uiPanelControllers[type].ShowPanel();
            }
        }

        private void SetupPanel(IUIPanelController uiPanelController)
        {
            _uiPanelControllers.Add(uiPanelController.GetType(), uiPanelController);
        }
    }
}