using UnityEngine;
using System.Collections.Generic;
using ZeroProject.Level.Room;
using ZeroProject.Level.Room.Realisation;

namespace ZeroProject.Level
{
    public class LevelGenerator
    {
        private const int MinimumTreasureRooms = 1;
        private const int MaximumTreasureRooms = 3;
        private const int MinimumRoomsCount = 10;
        private const int MaximumRoomsCount = 30;
        
        private readonly RoomStorage _roomStorage;

        public LevelGenerator(RoomStorage roomStorage)
        {
            _roomStorage = roomStorage;
        }

        public List<Room.Room> GenerateLevel()
        {
            var roomsCount = Random.Range(MinimumRoomsCount, MaximumRoomsCount);
            var treasureRoomCount = Random.Range(MinimumTreasureRooms, MaximumTreasureRooms);
            
            var result = new List<Room.Room>();
            
            var currentTreasureRoomCount = 0;
            
            for (var i = 0; i < roomsCount; i++)
            {
                Room.Room room;
                if (i == 0)
                {
                    room = _roomStorage.Get<EnterRoom>();
                    result.Add(room);
                    break;
                }

                if (currentTreasureRoomCount < treasureRoomCount)
                {
                    room = _roomStorage.Get<TreasureRoom>();
                    result.Add(room);
                    currentTreasureRoomCount++;
                    break;
                }
                
                if (result.Count == roomsCount - 1)
                {
                    room = _roomStorage.Get<BossRoom>();
                    result.Add(room);
                    break;
                }

                room = _roomStorage.Get<BattleRoom>();
                result.Add(room);
            }

            return result;
        }
    }
}