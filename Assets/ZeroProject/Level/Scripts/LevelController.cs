using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZeroProject.Extensions.ListExtensions;
using Random = UnityEngine.Random;

namespace ZeroProject.Level
{
    public class LevelController
    {
        private readonly LevelGenerator _levelGenerator;
        private readonly LevelRoot _levelRoot;
        private readonly IInstantiator _instantiator;
        
        private readonly Dictionary<int, GameObject> _instRooms = new Dictionary<int, GameObject>();
        private readonly Dictionary<int, Room.Room> _roomStorage = new Dictionary<int, Room.Room>();

        public LevelController(
            LevelGenerator levelGenerator,
            LevelRoot levelRoot,
            IInstantiator instantiator)
        {
            _levelGenerator = levelGenerator;
            _levelRoot = levelRoot;
            _instantiator = instantiator;
        }

        public void LoadLevel()
        {
            var roomViews = _levelGenerator.GenerateLevel();

            for (int i = 0; i < roomViews.Count; i++)
            {
                if (i == 0)
                {
                    Init(roomViews.First(), i, _levelRoot.PoolContainer);
                    break;
                }

                if (i == roomViews.Count - 1)
                {
                    Init(roomViews.Last(), i, _levelRoot.PoolContainer);
                    break;
                }
                
                var index = Random.Range(1, roomViews.Count - 1);
                Init(roomViews[index], i, _levelRoot.PoolContainer);
                _roomStorage.Add(i, roomViews[index]);
                roomViews.RemoveAt(index);
            }
        }

        public Room.Room Show(int id)
        {
            if (_instRooms.ContainsKey(id))
            {
                var view = _instRooms[id];
                view.transform.SetParent(_levelRoot.Container);
                view.transform.localPosition = Vector3.zero;
                view.transform.localScale = Vector3.one;
                view.transform.localRotation = Quaternion.identity;

                var component = _instRooms[id].GetComponent<Room.Room>();
                component.Show();
                return component;
            }

            return null;
        }

        public void Hide(int id)
        {
            if (_instRooms.ContainsKey(id))
            {
                var view = _instRooms[id];
                
                view.transform.SetParent(_levelRoot.PoolContainer);

                var component = _instRooms[id].GetComponent<Room.Room>();
                component.Hide();
            }
        }
        
        public Room.Room Get(int id)
        {
            if (_instRooms.ContainsKey(id))
            {
                var view = _instRooms[id];
                return view.GetComponent<Room.Room>();
            }

            return null;
        }
        

        private void Init(Room.Room prefab, int id, Transform parent = null)
        {
            GameObject instRoom;
            if (parent == null)
            {
                instRoom = _instantiator.InstantiatePrefab(prefab);
            }
            else
            {
                instRoom = _instantiator.InstantiatePrefab(prefab, Vector3.zero, Quaternion.identity, parent);
            }

            _instRooms.Add(id, instRoom);
        }
    }
}