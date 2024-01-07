using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZeroProject.SceneStorage;

namespace ZeroProject.LevelStorage.SceneService
{
    public class LevelService
    {
        private readonly IInstantiator _instantiator;
        private readonly LevelRoot _levelRoot;

        private readonly Dictionary<Type, Level> _levelStorage = new Dictionary<Type, Level>();
        private readonly Dictionary<Type, GameObject> _instViews = new Dictionary<Type, GameObject>();

        public LevelService(IInstantiator instantiator,
            LevelRoot levelRoot)
        {
            _instantiator = instantiator;
            _levelRoot = levelRoot;
        }

        public void LoadLevels()
        {
            var levels = Resources.LoadAll("Levels", typeof(Level));

            foreach (var level in levels)
            {
                _levelStorage.Add(level.GetType(), (Level)level);
            }
        }

        public void InitWindows()
        {
            foreach (var sceneLevel in _levelStorage)
            {
                Init(sceneLevel.Key);
            }
        }

        public T Show<T>() where T : Level
        {
            var type = typeof(T);
            if (_instViews.ContainsKey(type))
            {
                var view = _instViews[type];
                
                view.transform.localPosition = Vector3.zero;
                view.transform.localScale = Vector3.zero;
                view.transform.localRotation = Quaternion.identity;
                view.transform.SetParent(_levelRoot.Container);

                var component = view.GetComponent<T>();
                
                component.ShowScene();
                return component;
            }

            return null;
        }   
        
        public void Hide<T>(Action onEnd = null) where T : Level
        {
            var type = typeof(T);
            if (_instViews.ContainsKey(type))
            {
                var view = _instViews[type];
                var viewComponent = view.GetComponent<T>();
                
                view.transform.localPosition = Vector3.zero;
                view.transform.localScale = Vector3.zero;
                view.transform.localRotation = Quaternion.identity;
                view.transform.SetParent(_levelRoot.PoolContainer);

                viewComponent.HideScene();
            }
        } 

        private void Init(Type type, Transform parent = null)
        {
            if (_levelStorage.ContainsKey(type) && !_instViews.ContainsKey(type))
            {
                GameObject view;

                if (parent != null)
                {
                    view = _instantiator.InstantiatePrefab(_levelStorage[type], parent);
                }
                else
                {
                    view = _instantiator.InstantiatePrefab(_levelStorage[type]);
                }
                
                _instViews.Add(type, view);
            }
        }

        public T Get<T>() where T : Level
        {
            var type = typeof(T);
            if (_instViews.ContainsKey(type))
            {
                var view = _levelStorage[type];
                return view.GetComponent<T>();
            }

            return null;
        }
    }
}