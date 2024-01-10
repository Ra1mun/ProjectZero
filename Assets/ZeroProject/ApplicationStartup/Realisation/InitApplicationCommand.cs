using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZeroProject.Bootstrap.Interfaces;
using ZeroProject.UI.Realisation;

public class InitApplicationCommand : ICommand
{
    private readonly UIPanelsController _uiPanelsController;
    public Action Done { get; set; }

    public InitApplicationCommand(UIPanelsController uiPanelsController)
    {
        _uiPanelsController = uiPanelsController;
    }
    
    public void Execute()
    {
        _uiPanelsController.ShowFirstPanel();
        
        Done?.Invoke();
    }
}
