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
            _roomStorage.Add(typeof(BattleRoom), Load(source + '/' + "BattleRooms"));
            _roomStorage.Add(typeof(BossRoom), Load(source + '/' + "BossRooms"));
            _roomStorage.Add(typeof(EnterRoom), Load(source + '/' + "EnterRooms"));
            _roomStorage.Add(typeof(TreasureRoom), Load(source + '/' + "TreasureRooms"));
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
        
        private List<Room> Load(string path)
        {
            var result = new List<Room>();
            var rooms = Resources.LoadAll(path, typeof(Room));
            
            Debug.Log(path);
            Debug.Log(rooms.Length);
            foreach (var room in rooms)
            {
                result.Add((Room)room);
            }

            return result;
        }
    }
}
