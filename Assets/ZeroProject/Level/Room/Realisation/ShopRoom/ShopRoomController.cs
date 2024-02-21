using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class ShopRoomController : IRoomController
    {
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;
        
        
        public void Initialize(LevelController levelController)
        {
            throw new NotImplementedException();
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