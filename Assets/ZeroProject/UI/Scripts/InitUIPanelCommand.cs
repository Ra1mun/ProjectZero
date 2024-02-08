using System;
using ZeroProject.Bootstrap.Interfaces;

namespace ZeroProject.UI.Realisation
{
    public class InitUIPanelCommand : ICommand
    {
        private readonly UIService _uiService;
        private readonly DevelopmentSettings _developmentSettings;
        public Action Done { get; set; }
        
        public InitUIPanelCommand(
            UIService uiService, 
            DevelopmentSettings developmentSettings)
        {
            _uiService = uiService;
            _developmentSettings = developmentSettings;
        }

        public void Execute()
        {
            _uiService.LoadPanels(_developmentSettings.SceneType);
            _uiService.InitPanels();
            
            Done?.Invoke();
        }
    }
}