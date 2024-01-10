using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZeroProject.Bootstrap.Interfaces;
using ZeroProject.UI.Realisation;
using ZeroProject.UI.Realisation.MenuPanel;

public class InitApplicationCommand : ICommand
{
    private readonly MainMenuPanelController _mainMenuPanelController;
    private readonly DevelopmentSettings _developmentSettings;
    private readonly UIService _uiService;
    public Action Done { get; set; }

    public InitApplicationCommand(MainMenuPanelController mainMenuPanelController,
        DevelopmentSettings developmentSettings)
    {
        _mainMenuPanelController = mainMenuPanelController;
        _developmentSettings = developmentSettings;
    }
    
    public void Execute()
    {
        if (_developmentSettings.UIType == UIType.MainMenu)
        {
            _mainMenuPanelController.ShowPanel();
        }

        Done?.Invoke();
    }
}
