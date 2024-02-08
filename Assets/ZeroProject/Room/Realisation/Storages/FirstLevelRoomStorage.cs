using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ZeroProject.Room.Realisation
{
    public class FirstLevelRoomStorage : RoomStorage
    {
        private readonly Dictionary<Type, Room> _singleRoomStorage = new Dictionary<Type, Room>();
        private readonly Dictionary<Type, Room[]> _defualtRoomStorage = new Dictionary<Type, Room[]>();

        [NonSerialized] private bool isInit;

        public FirstLevelRoomStorage()
        {

        }

        protected override void Initialize()
        {
            base.Initialize();

            _defualtRoomStorage.Add(battleRooms[0].GetType(), battleRooms);
            _defualtRoomStorage.Add(treasureRooms[0].GetType(), treasureRooms);

            _singleRoomStorage.Add(bossRoom.GetType(), bossRoom);
            _singleRoomStorage.Add(shopRoom.GetType(), shopRoom);
            _singleRoomStorage.Add(enterRoom.GetType(), enterRoom);

            isInit = true;
        }

        public override Room GetRandomRoom()
        {
            if(!isInit)
            {
                Initialize();
            }

            
        }

        public override T GetRoom<T>()
        {
            throw new NotImplementedException();
        }
    }
}

