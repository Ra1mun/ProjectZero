using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ZeroProject.UI.Realisation
{
    public class UIService
    {
        private readonly IInstantiator _instantiator;
        private Dictionary<Type, UIPanelView> _uiPanelsStorage = new Dictionary<Type, UIPanelView>();
        private Dictionary<Type, GameObject> _instViews = new Dictionary<Type, GameObject>();

        public UIService(
            IInstantiator instantiator,
            UIRoot uiRoot)
        {
            _instantiator = instantiator;
        }

        public void LoadPanels(UIType uiType)
        {
            var panels = Resources.LoadAll(uiType == UIType.MainMenu ? "MainMenuPanels" : "GamePanels", typeof(UIPanelView));

            foreach (var panel in panels)
            {
                _uiPanelsStorage.Add(panel.GetType(), (UIPanelView)panel); 
            }
        }

        public void InitPanels()
        {
            foreach (var panel in _uiPanelsStorage.Keys)
            {
                Init(panel);
            }
        }

        private void Init(Type type, Transform parent = null)
        {
            if (_uiPanelsStorage.ContainsKey(type))
            {
                GameObject view;
                
                if (parent != null)
                {
                    view = _instantiator.InstantiatePrefab(_uiPanelsStorage[type], parent);
                }
                else
                {
                    view = _instantiator.InstantiatePrefab(_uiPanelsStorage[type]);
                }
                
                _instViews.Add(type, view);
            }
        }
    }

    public enum UIType
    {
        MainMenu,
        Game,
    }
}