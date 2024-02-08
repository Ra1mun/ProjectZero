using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroProject.SceneObject.Realisation
{
    public class SceneObjectStorage
    {
        private Dictionary<Type, SceneObject> _sceneObjectsStorage = new Dictionary<Type, SceneObject>();

        public T CreateAndAdd<T>(string source, Transform parent = null) where T : SceneObject
        {
            var obj = Resources.Load<T>(source);

            var type = typeof(T);
            
            if (obj == null)
            {
                Debug.LogError($"Object with type \"{type}\" not found in {source}");
                return null;
            }
            
            if (_sceneObjectsStorage.ContainsKey(type))
            {
                Debug.LogError($"Object with type \"{type}\" has already been added");
                return null;
            }
            
            var instObj = GameObject.Instantiate(obj);
            
            _sceneObjectsStorage.Add(type, instObj);

            return instObj;
        }
        
        public void Add<T>(SceneObject obj) where T : SceneObject
        {
            var type = typeof(T);

            if (_sceneObjectsStorage.ContainsKey(type))
            {
                Debug.LogError($"Object with type \"{type}\" has already been added");
                return;
            }
            
            _sceneObjectsStorage.Add(type, obj);
        }

        public T Get<T>() where T : SceneObject
        {
            var type = typeof(T);

            if (_sceneObjectsStorage.ContainsKey(type))
            {
                return (T)_sceneObjectsStorage[type];
            }

            Debug.LogError($"Object with type \"{type}\" is not found for getting");
            return default;
        }

        public bool Contains<T>() where T : SceneObject
        {
            var type = typeof(T);

            if (_sceneObjectsStorage.ContainsKey(type))
            {
                return true;
            }
            
            return false;
        }

        public void Remove<T>() where T : SceneObject
        {
            var type = typeof(T);

            if (_sceneObjectsStorage.ContainsKey(type))
            {
                UnityEngine.Object.Destroy(_sceneObjectsStorage[type].gameObject);
                _sceneObjectsStorage.Remove(type);
                
                return;
            }

            Debug.LogError($"Object with type \"{type}\" is not found for removing");
        }
    }
}