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

        public (List<Room.Room>, List<IRoomController>) GenerateLevel()
        {
            var roomsCount = Random.Range(MinimumRoomsCount, MaximumRoomsCount);
            var treasureRoomCount = Random.Range(MinimumTreasureRooms, MaximumTreasureRooms);
            
            var item1 = new List<Room.Room>();
            var item2 = new List<IRoomController>();
            
            var currentTreasureRoomCount = 0;
            
            for (var i = 0; i < roomsCount; i++)
            {
                Room.Room room;
                IRoomController roomController;
                if (i == 0)
                {
                    room = _roomStorage.Get<EnterRoom>();
                    roomController = new EnterRoomController((EnterRoom)room);
                    item1.Add(room);
                    item2.Add(roomController);
                    break;
                }

                if (currentTreasureRoomCount < treasureRoomCount)
                {
                    room = _roomStorage.Get<TreasureRoom>();
                    roomController = new TreasureRoomController((TreasureRoom)room);
                    item1.Add(room);
                    item2.Add(roomController);
                    currentTreasureRoomCount++;
                    break;
                }
                
                if (item1.Count == roomsCount - 1)
                {
                    room = _roomStorage.Get<BossRoom>();
                    roomController = new BossRoomController((BossRoom)room);
                    item1.Add(room);
                    item2.Add(roomController);
                    break;
                }

                room = _roomStorage.Get<BattleRoom>();
                roomController = new BattleRoomController((BattleRoom) room);
                item1.Add(room);
                item2.Add(roomController);
            }

            return (item1, item2);
        }
    }
}