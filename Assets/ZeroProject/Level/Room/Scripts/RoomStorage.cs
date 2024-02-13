using System;
using System.Collections.Generic;
using UnityEngine;
using ZeroProject.Extensions.ListExtensions;
using ZeroProject.Level.Room.Realisation;


namespace ZeroProject.Level.Room
{
    public class RoomStorage
    {
        private readonly Dictionary<Type, List<Room>> _roomStorage = new Dictionary<Type, List<Room>>();

        public void LoadRooms(string source)
        {
            _roomStorage.Add(typeof(BattleRoom), Load<BattleRoom>("BattleRooms"));
            _roomStorage.Add(typeof(BossRoom), Load<BossRoom>("BossRooms"));
            _roomStorage.Add(typeof(EnterRoom), Load<EnterRoom>("EnterRooms"));
            _roomStorage.Add(typeof(TreasureRoom), Load<TreasureRoom>("TreasureRooms"));
        }

        private List<Room> Load<T>(string source) where T : Room
        {
            var result = new List<Room>();
            var rooms = Resources.LoadAll(source, typeof(T));
            
            foreach (var room in rooms)
            {
                result.Add((Room)room);
            }

            return result;
        }

        public Room Get<T>() where T : Room
        {
            var type = typeof(T);
            if (_roomStorage.ContainsKey(type))
            {
                return _roomStorage[type].RandomItem();
            }

            return null;
        }
    }
}
