using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZeroProject.Extensions.ListExtensions;
using ZeroProject.Room.Interfaces;
using Random = UnityEngine.Random;

namespace ZeroProject.Level
{
    public class LevelController
    {
        private readonly LevelGenerator _levelGenerator;
        private readonly LevelRoot _levelRoot;
        private readonly IInstantiator _instantiator;
        
        private readonly List<GameObject> _instRooms = new List<GameObject>();
        private readonly List<Room.Room> _roomStorage = new List<Room.Room>();
        
        private readonly LinkedList<IRoomController> _roomControllers = new LinkedList<IRoomController>();

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
            var generateLevel = _levelGenerator.GenerateLevel();

            for (int i = 0; i < generateLevel.Item1.Count; i++)
            {
                Init(generateLevel.Item1[i], _levelRoot.PoolContainer);
                SetupController(generateLevel.Item2[i]);
                _roomStorage.Add(generateLevel.Item1[i]);
            }
        }
        
        public void ShowFirstRoom()
        {
            _roomControllers.First?.Value.ShowRoom();
        }

        public void Show(Room.Room room)
        {
            if (_roomStorage.Contains(room))
            {
                var index = _roomStorage.IndexOf(room);
                var view = _instRooms[index];
                view.transform.SetParent(_levelRoot.Container);
                view.transform.localPosition = Vector3.zero;
                view.transform.localScale = Vector3.one;
                view.transform.localRotation = Quaternion.identity;

                var component = _instRooms[index].GetComponent<Room.Room>();
                component.Show();
            }
        }

        public void Hide(Room.Room room)
        {
            if (_roomStorage.Contains(room))
            {
                var index = _roomStorage.IndexOf(room);
                var view = _instRooms[index];
                
                view.transform.SetParent(_levelRoot.PoolContainer);

                var component = _instRooms[index].GetComponent<Room.Room>();
                component.Hide();
            }
        }


        private void Init(Room.Room prefab, Transform parent = null)
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

            _instRooms.Add(instRoom);
        }

        private void SetupController(IRoomController roomController)
        {
            roomController.Initialize(this);
            
            if (_roomControllers.Last != null)
            {
                _roomControllers.Last.Value.GoToNextRoom += roomController.ShowRoom;

                roomController.GoToPreviousRoom += _roomControllers.Last.Value.ShowRoom;
            }

            _roomControllers.AddLast(roomController);
        }
    }
}