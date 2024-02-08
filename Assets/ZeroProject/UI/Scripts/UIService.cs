using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Object = System.Object;

namespace ZeroProject.UI.Realisation
{
    public class UIService
    {
        private readonly IInstantiator _instantiator;
        private readonly UIRoot _uiRoot;
        
        private Dictionary<Type, UIPanelView> _uiPanelsStorage = new Dictionary<Type, UIPanelView>();
        private Dictionary<Type, GameObject> _instViews = new Dictionary<Type, GameObject>();

        public UIService(
            IInstantiator instantiator,
            UIRoot uiRoot)
        {
            _instantiator = instantiator;
            _uiRoot = uiRoot;
        }

        public void LoadPanels(UIType uiType)
        {
            UnityEngine.Object[] panels;
            switch (uiType)
            {
                case UIType.MainMenu:
                    panels = Resources.LoadAll("MainMenuPanels", typeof(UIPanelView));
                    break;
                case UIType.Game:
                    panels = Resources.LoadAll("GamePanels", typeof(UIPanelView));
                    break;
                default:
                    throw new KeyNotFoundException($"Panels with type { uiType } not found!");
            }

            foreach (var panel in panels)
            {
                _uiPanelsStorage.Add(panel.GetType(), (UIPanelView)panel); 
            }
        }

        public void InitPanels()
        {
            foreach (var panel in _uiPanelsStorage.Keys)
            {
                Init(panel, _uiRoot.PoolContainer);
            }
        }

        public T Show<T>() where T : UIPanelView
        {
            var type = typeof(T);
            if (_instViews.ContainsKey(type))
            {
                var view = _instViews[type];
                
                view.transform.localPosition = Vector3.zero;
                view.transform.localScale = Vector3.one;
                view.transform.localRotation = Quaternion.identity;
                view.transform.SetParent(_uiRoot.Container);

                var component = view.GetComponent<T>();
                
                component.Show();
                return component;
            }

            return null;
        }
        
        public void Hide<T>(Action onEnd = null) where T : UIPanelView
        {
            var type = typeof(T);
            if (_instViews.ContainsKey(type))
            {
                var view = _instViews[type];
                var viewComponent = view.GetComponent<T>();
                
                view.transform.localPosition = Vector3.zero;
                view.transform.localScale = Vector3.zero;
                view.transform.localRotation = Quaternion.identity;
                view.transform.SetParent(_uiRoot.PoolContainer);

                viewComponent.Hide();
            }
            
            onEnd?.Invoke();
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
        
        public T Get<T>() where T : UIPanelView
        {
            var type = typeof(T);
            if (_instViews.ContainsKey(type))
            {
                var view = _uiPanelsStorage[type];
                return view.GetComponent<T>();
            }

            return null;
        }
    }

    public enum UIType
    {
        MainMenu,
        Game,
    }
}