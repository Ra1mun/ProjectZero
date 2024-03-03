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
    public class LevelService
    {
        private readonly LevelGenerator _levelGenerator;
        private readonly LevelRoot _levelRoot;
        private readonly IInstantiator _instantiator;
        private readonly RoomStorage _roomStorage;
        private readonly RoomsController _roomsController;

        private readonly Dictionary<int, GameObject> _instRooms = new Dictionary<int, GameObject>();
        
        public LevelService(
            LevelGenerator levelGenerator,
            LevelRoot levelRoot,
            IInstantiator instantiator,
            RoomStorage roomStorage,
            RoomsController roomsController)
        {
            _levelGenerator = levelGenerator;
            _levelRoot = levelRoot;
            _instantiator = instantiator;
            _roomStorage = roomStorage;
            _roomsController = roomsController;
        }

        public void LoadLevel()
        {
            var roomTypes = _levelGenerator.GenerateLevel();

            for (int i = 0; i < roomTypes.Count; i++)
            {
                if (i == 0 || i == roomTypes.Count - 2)
                {
                    Init(roomTypes[i], _levelRoot.PoolContainer);
                }
                else
                {
                    var index = Random.Range(1, roomTypes.Count);
                    Init(roomTypes[index], _levelRoot.PoolContainer);
                }
                
            }
        }

        public void Show(int id)
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
            }
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

        private void Init(RoomType type, Transform parent = null)
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
            
            _roomsController.SetupRoom(GetController(type, component));

            _instRooms.Add(instRoom.GetInstanceID(), instRoom);
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