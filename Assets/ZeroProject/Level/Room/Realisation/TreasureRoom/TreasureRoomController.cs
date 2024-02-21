using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class TreasureRoomController : IRoomController
    {
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;
        
        private readonly TreasureRoom _treasureRoom;
        private LevelController _levelController;

        public TreasureRoomController(TreasureRoom treasureRoom)
        {
            _treasureRoom = treasureRoom;
        }

        public void Initialize(LevelController levelController)
        {
            _levelController = levelController;
        }

        public void ShowRoom()
        {
            throw new NotImplementedException();
        }

        public void HideRoom()
        {
            throw new NotImplementedException();
        }
    }
}