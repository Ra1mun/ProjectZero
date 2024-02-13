using System;
using ZeroProject.Bootstrap.Interfaces;
using ZeroProject.Level;

namespace ZeroProject.Level.Room
{
    public class InitRoomCommand : ICommand
    {
        private readonly RoomStorage _roomStorage;
        private readonly LevelController _levelController;
        public Action Done { get; set; }
        
        public InitRoomCommand(RoomStorage roomStorage, LevelController levelController)
        {
            _roomStorage = roomStorage;
            _levelController = levelController;
        }

        public void Execute()
        {
            _roomStorage.LoadRooms("TestLevel");
            _levelController.LoadLevel();
            
            Done?.Invoke();
        }
    }
}