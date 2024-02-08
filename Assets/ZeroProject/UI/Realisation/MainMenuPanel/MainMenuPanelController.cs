using System;
using ZeroProject.UI.Interfaces;

namespace ZeroProject.UI.Realisation.MenuPanel
{
    public class MainMenuPanelController : IUIPanelController
    {
        public event Action OnPlayClicked;

        private readonly UIService _uiService;
        private readonly MainMenuPanelView _mainMenuPanelView;

        public MainMenuPanelController(UIService uiService)
        {
            _uiService = uiService;

            _mainMenuPanelView = _uiService.Get<MainMenuPanelView>();
        }


        public void ShowPanel()
        {
            _mainMenuPanelView.OnPlayButtonClickEvent += OnPlayButtonClick;
            
            _uiService.Show<MainMenuPanelView>();
        }

        private void OnPlayButtonClick()
        {
            OnPlayClicked?.Invoke();
            
            HidePanel();
        }

        public void HidePanel()
        {
            _mainMenuPanelView.OnPlayButtonClickEvent -= OnPlayButtonClick;
            
            _uiService.Hide<MainMenuPanelView>();
        }
    }
}