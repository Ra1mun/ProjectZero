using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ZeroProject.SceneStorage
{
    public class SceneService
    {
        private readonly IInstantiator _instantiator;
        private readonly SceneRoot _sceneRoot;

        private readonly Dictionary<Type, Scene> _levelStorage = new Dictionary<Type, Scene>();
        private readonly Dictionary<Type, GameObject> _instViews = new Dictionary<Type, GameObject>();

        public SceneService(IInstantiator instantiator,
            SceneRoot sceneRoot)
        {
            _instantiator = instantiator;
            _sceneRoot = sceneRoot;
        }

        public void LoadLevels()
        {
            var levels = Resources.LoadAll("SceneLevels", typeof(Scene));

            foreach (var level in levels)
            {
                _levelStorage.Add(level.GetType(), (Scene)level);
            }
        }

        public void InitWindows()
        {
            foreach (var sceneLevel in _levelStorage)
            {
                Init(sceneLevel.Key);
            }
        }

        public T Show<T>() where T : Scene
        {
            var type = typeof(T);
            if (_instViews.ContainsKey(type))
            {
                var view = _instViews[type];
                
                view.transform.localPosition = Vector3.zero;
                view.transform.localScale = Vector3.zero;
                view.transform.localRotation = Quaternion.identity;
                view.transform.SetParent(_sceneRoot.Container);

                var component = view.GetComponent<T>();
                
                component.ShowScene();
                return component;
            }

            return null;
        }   
        
        public void Hide<T>(Action onEnd = null) where T : Scene
        {
            var type = typeof(T);
            if (_instViews.ContainsKey(type))
            {
                var view = _instViews[type];
                var viewComponent = view.GetComponent<T>();
                
                view.transform.localPosition = Vector3.zero;
                view.transform.localScale = Vector3.zero;
                view.transform.localRotation = Quaternion.identity;
                view.transform.SetParent(_sceneRoot.PoolContainer);

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

        public T Get<T>() where T : Scene
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