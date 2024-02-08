using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZeroProject.Extensions.ListExtensions;
using Random = UnityEngine.Random;

namespace ZeroProject.Level
{
    public class LevelBuilder
    {
        private readonly LevelGenerator _levelGenerator;
        private readonly LevelRoot _levelRoot;
        private readonly IInstantiator _instantiator;
        private readonly List<GameObject> _instRooms = new List<GameObject>();
        
        private List<Room.Room> _roomViews = new List<Room.Room>();

        public LevelBuilder(
            LevelGenerator levelGenerator,
            LevelRoot levelRoot,
            IInstantiator instantiator)
        {
            _levelGenerator = levelGenerator;
            _levelRoot = levelRoot;
            _instantiator = instantiator;
            
            SetupLevel();
        }

        private void SetupLevel()
        {
            _roomViews = _levelGenerator.GenerateLevel();

            for (int i = 0; i < _roomViews.Count; i++)
            {
                if (i == 0)
                {
                    AddRoom(_roomViews.First(), _levelRoot.PoolContainer);
                    break;
                }

                if (i == _roomViews.Count - 1)
                {
                    AddRoom(_roomViews.Last(), _levelRoot.PoolContainer);
                    break;
                }
                
                var index = Random.Range(1, _roomViews.Count - 1);
                AddRoom(_roomViews[index], _levelRoot.PoolContainer);
            }
        }
        
        public void ShowFirstRoom()
        {
            _instRooms[0].transform.SetParent(_levelRoot.Container);
        }

        private void AddRoom(Room.Room prefab, Transform parent = null)
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
            
            if (_instRooms.Count == 0)
            {
                _instRooms[0].transform.localPosition = Vector3.zero;
            }
            else
            {
                instRoom.transform.localPosition 
                    = ConnectRooms(
                        _instRooms.Last().GetComponent<Room.Room>(),
                        instRoom.GetComponent<Room.Room>());
            }
            
            _instRooms.Add(instRoom);

            
        }

        private Vector3 ConnectRooms(Room.Room currentRoom, Room.Room nextRoom)
        {
            var transitionPoint = currentRoom
                .TransitionPoints
                .TransitPoints
                .RandomItem()
                .position;
            
            var enterPoint = nextRoom
                .TransitionPoints
                .EnterPoint
                .position;
            
            return nextRoom.transform.position + (enterPoint - transitionPoint);
        }
    }
}