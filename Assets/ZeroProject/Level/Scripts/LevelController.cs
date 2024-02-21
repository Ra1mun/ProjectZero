using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using ZeroProject.Extensions.ListExtensions;
using ZeroProject.Level.Room;
using ZeroProject.Level.Room.Realisation;
using ZeroProject.Room.Interfaces;
using Random = UnityEngine.Random;

namespace ZeroProject.Level
{
    public class LevelController
    {
        private readonly LevelGenerator _levelGenerator;
        private readonly LevelRoot _levelRoot;
        private readonly IInstantiator _instantiator;
        private readonly RoomStorage _roomStorage;

        private readonly List<GameObject> _instRooms = new List<GameObject>();
        private readonly List<Room.Room> _roomViews = new List<Room.Room>();
        private readonly LinkedList<IRoomController> _roomControllers = new LinkedList<IRoomController>();

        public LevelController(
            LevelGenerator levelGenerator,
            LevelRoot levelRoot,
            IInstantiator instantiator,
            RoomStorage roomStorage)
        {
            _levelGenerator = levelGenerator;
            _levelRoot = levelRoot;
            _instantiator = instantiator;
            _roomStorage = roomStorage;
        }

        public void LoadLevel()
        {
            var roomTypes = _levelGenerator.GenerateLevel();

            for (int i = 0; i < roomTypes.Count; i++)
            {
                if (i == 0 || i == roomTypes.Count - 2)
                {
                    AddRoom(roomTypes[i], _levelRoot.PoolContainer);
                }
                else
                {
                    var index = Random.Range(1, roomTypes.Count);
                    AddRoom(roomTypes[index], _levelRoot.PoolContainer);
                }
                
            }
        }
        
        public void ShowFirstRoom()
        {
            _roomControllers.First?.Value.ShowRoom();
        }

        public void Show(Room.Room room)
        {
            if (_roomViews.Contains(room))
            {
                var index = _roomViews.IndexOf(room);
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
            if (_roomViews.Contains(room))
            {
                var index = _roomViews.IndexOf(room);
                var view = _instRooms[index];
                
                view.transform.SetParent(_levelRoot.PoolContainer);

                var component = _instRooms[index].GetComponent<Room.Room>();
                component.Hide();
            }
        }

        private void AddRoom(RoomType type, Transform parent = null)
        {
            GameObject instRoom;
            if (parent == null)
            {
                instRoom = _instantiator.InstantiatePrefab(_roomStorage.Get(type));
            }
            else
            {
                instRoom = _instantiator.InstantiatePrefab(_roomStorage.Get(type), parent);
            }
            
            var component = instRoom.GetComponent<Room.Room>();
            
            SetupRoom(GetController(type, component));

            _instRooms.Add(instRoom);
            _roomViews.Add(component);
        }
        
        private void SetupRoom(IRoomController roomController)
        {
            if (_roomControllers.Last != null)
            {
                _roomControllers.Last.Value.GoToNextRoom += roomController.ShowRoom;

                roomController.GoToPreviousRoom += _roomControllers.Last.Value.ShowRoom;
            }

            _roomControllers.AddLast(roomController);
        }

        private IRoomController GetController(RoomType type, Room.Room prefab)
        {
            switch (type)
            {
                case RoomType.Battle:
                    return new BattleRoomController(
                        (BattleRoom)prefab,
                        this);
                case RoomType.Boss:
                    return new BossRoomController(
                        (BossRoom)prefab, 
                        this);
                case RoomType.Enter:
                    return new EnterRoomController(
                        (EnterRoom)prefab,
                        this);
                case RoomType.Shop:
                    return new ShopRoomController(
                        (ShopRoom)prefab,
                        this);
                case RoomType.Treasure:
                    return new TreasureRoomController(
                        (TreasureRoom)prefab,
                        this);
                default:
                    throw new NotImplementedException($"Controller with type {type} not found!");
            }
        }
    }
}