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

        public void InitLevel()
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
                    var index = Random.Range(1, roomTypes.Count - 1);
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

        private IRoomController GetController(RoomType type, Room.Room viewComponent)
        {
            switch (type)
            {
                case RoomType.Battle:
                    return _instantiator.Instantiate<BattleRoomController>(new object[]
                    {
                        (BattleRoom) viewComponent
                    });
                case RoomType.Boss:
                    return _instantiator.Instantiate<BossRoomController>(new object[]
                    {
                        (BossRoom) viewComponent
                    });
                case RoomType.Enter:
                    return _instantiator.Instantiate<EnterRoomController>(new object[]
                    {
                        (EnterRoom) viewComponent
                    });
                case RoomType.Shop:
                    return _instantiator.Instantiate<ShopRoomController>(new object[]
                    {
                        (ShopRoom) viewComponent
                    });
                case RoomType.Treasure:
                    return _instantiator.Instantiate<TreasureRoomController>(new object[]
                    {
                        (TreasureRoom) viewComponent
                    });
                default:
                    throw new NotImplementedException($"Controller with type {type} not found!");
            }
        }
    }
}