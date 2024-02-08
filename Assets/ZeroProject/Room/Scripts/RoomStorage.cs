using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZeroProject.Extensions.ListExtensions;
using Object = UnityEngine.Object;

namespace ZeroProject.Room
{
    public class RoomStorage
    {
        private readonly Dictionary<RoomType, List<Room>> _roomStorage = new Dictionary<RoomType, List<Room>>();

        public void LoadRooms()
        {
            _roomStorage.Add(RoomType.Battle, Load(RoomType.Battle));
            _roomStorage.Add(RoomType.Boss, Load(RoomType.Boss));
            _roomStorage.Add(RoomType.Enter, Load(RoomType.Enter));
            _roomStorage.Add(RoomType.Shop, Load(RoomType.Shop));
            _roomStorage.Add(RoomType.Treasure, Load(RoomType.Treasure));
        }

        private List<Room> Load(RoomType type)
        {
            var result = new List<Room>();

            Object[] rooms;
            switch (type)
            {
                case RoomType.Battle:
                    rooms = Resources.LoadAll("TestLevel/BattleRoom", typeof(Room));
                    break;
                case RoomType.Boss:
                    rooms = Resources.LoadAll("TestLevel/BossRoom", typeof(Room));
                    break;
                case RoomType.Enter:
                    rooms = Resources.LoadAll("TestLevel/EnterRoom", typeof(Room));
                    break;
                case RoomType.Shop:
                    rooms = Resources.LoadAll("TestLevel/ShopRoom", typeof(Room));
                    break;
                case RoomType.Treasure:
                    rooms = Resources.LoadAll("TestLevel/TreasureRoom", typeof(Room));
                    break;
                default:
                    throw new Exception($"Type of {type} is not found!");
            }

            foreach (var room in rooms)
            {
                result.Add((Room)room);
            }

            return result;
        }

        public Room GetRoom(RoomType type)
        {
            if (_roomStorage.ContainsKey(type))
            {
                return _roomStorage[type].RandomItem();
            }

            return null;
        }
    }
}
