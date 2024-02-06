using System;
using UnityEngine;
using UnityEngine.UI;

namespace ZeroProject.UI.Realisation.MenuPanel
{
    public class MainMenuPanelView : UIPanelView
    {
        public event Action OnPlayButtonClickEvent;
        
        [SerializeField] private Button _playButton;
        
        public override void Show()
        {
            _playButton.onClick.AddListener(OnPlayButtonClick);
        }

        private void OnPlayButtonClick()
        {
            OnPlayButtonClickEvent?.Invoke();
        }

        public override void Hide()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClick);
        }
    }
}