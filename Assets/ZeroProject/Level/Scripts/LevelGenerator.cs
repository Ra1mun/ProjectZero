using System.Collections.Generic;
using Zenject;
using ZeroProject.Room;
using ZeroProject.Room.Realisation;

namespace ZeroProject.Level
{
    public class LevelGenerator
    {
        private readonly RoomStorage _roomStorage;

        public LevelGenerator(RoomStorage roomStorage)
        {
            _roomStorage = roomStorage;
        }

        public List<Room.Room> GenerateLevel(int roomsCount, int treasureRoomCount)
        {
            var result = new List<Room.Room>();
            
            const int currentTreasureRoomCount = 0;
            
            for (var i = 0; i < roomsCount; i++)
            {
                Room.Room room;
                if (result[0] == null)
                {
                    room = _roomStorage.GetRoom(RoomType.Enter);
                    result.Add(room);
                    break;
                }

                if (currentTreasureRoomCount < treasureRoomCount)
                {
                    room = _roomStorage.GetRoom(RoomType.Treasure);
                    result.Add(room);
                    break;
                }
                
                if (result.Count == roomsCount - 1)
                {
                    room = _roomStorage.GetRoom(RoomType.Boss);
                    result.Add(room);
                    break;
                }

                room = _roomStorage.GetRoom(RoomType.Battle);
                result.Add(room);
            }

            return result;
        }
    }
}