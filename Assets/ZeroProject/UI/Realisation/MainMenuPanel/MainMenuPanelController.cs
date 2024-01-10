using ZeroProject.UI.Interfaces;

namespace ZeroProject.UI.Realisation.MenuPanel
{
    public class MainMenuPanelController : IUIPanelController
    {
        private readonly UIService _uiService;
        private readonly MainMenuPanelView _mainMenuPanelView;

        public MainMenuPanelController(UIService uiService)
        {
            _uiService = uiService;

            _mainMenuPanelView = _uiService.Get<MainMenuPanelView>();
        }


        public void ShowPanel()
        {
            _uiService.Show<MainMenuPanelView>();
        }

        public void HidePanel()
        {
            _uiService.Hide<MainMenuPanelView>();
        }
    }
}