using UnityEngine;
using System.Collections.Generic;
using ZeroProject.Level.Room;
using ZeroProject.Level.Room.Realisation;
using ZeroProject.Room.Interfaces;

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

        public List<RoomType> GenerateLevel()
        {
            var roomsCount = Random.Range(MinimumRoomsCount, MaximumRoomsCount);
            var treasureRoomCount = Random.Range(MinimumTreasureRooms, MaximumTreasureRooms);
            
            var result = new List<RoomType>();
            
            var currentTreasureRoomCount = 0;
            
            for (var i = 0; i < roomsCount; i++)
            {
                if (i == 0)
                {
                    result.Add(RoomType.Enter);
                    continue;
                }

                if (currentTreasureRoomCount < treasureRoomCount)
                {
                    result.Add(RoomType.Treasure);
                    currentTreasureRoomCount++;
                    continue;
                }
                
                if (result.Count == roomsCount - 1)
                {
                    result.Add(RoomType.Boss);
                    continue;
                }
                
                result.Add(RoomType.Battle);
            }

            return result;
        }
    }
}