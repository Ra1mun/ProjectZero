using System;
using ZeroProject.Bootstrap.Interfaces;

namespace ZeroProject.Room
{
    public class InitRoomCommand : ICommand
    {
        private readonly RoomStorage _roomStorage;
        public Action Done { get; set; }
        
        public InitRoomCommand(RoomStorage roomStorage)
        {
            _roomStorage = roomStorage;
        }

        public void Execute()
        {
            _roomStorage.LoadRooms();
            
            Done?.Invoke();
        }
    }
}