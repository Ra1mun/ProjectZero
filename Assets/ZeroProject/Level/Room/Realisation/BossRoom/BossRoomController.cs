using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class BossRoomController : IRoomController
    {
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;

        private readonly BossRoom _bossRoom;
        private LevelController _levelController;

        public BossRoomController(BossRoom bossRoom)
        {
            _bossRoom = bossRoom;
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