using System;
using System.Collections.Generic;
using UnityEngine;
using ZeroProject.Extensions.ListExtensions;
using ZeroProject.Level.Room.Realisation;


namespace ZeroProject.Level.Room
{
    public class RoomStorage
    {
        private readonly Dictionary<RoomType, List<Room>> _roomStorage = new Dictionary<RoomType, List<Room>>();

        public void LoadRooms(string source)
        {
            _roomStorage.Add(RoomType.Battle, Load(source + '/' + "BattleRooms"));
            _roomStorage.Add(RoomType.Boss, Load(source + '/' + "BossRooms"));
            _roomStorage.Add(RoomType.Enter, Load(source + '/' + "EnterRooms"));
            _roomStorage.Add(RoomType.Shop, Load(source + '/' + "ShopRooms"));
            _roomStorage.Add(RoomType.Treasure, Load(source + '/' + "TreasureRooms"));
        }

        public Room Get(RoomType type)
        {
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
            
            foreach (var room in rooms)
            {
                result.Add((Room)room);
            }

            return result;
        }
    }

    public enum RoomType
    {
        Battle,
        Boss,
        Enter,
        Shop,
        Treasure,
    }
}
