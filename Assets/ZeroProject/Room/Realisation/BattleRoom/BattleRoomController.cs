using System;

namespace ZeroProject.Room.Realisation.BattleRooms
{
    public class BattleRoomController : IRoomController
    {
        public Action GoToNextRoom { get; set; }
        public Action GoToPreviousRoom { get; set; }

        public BattleRoomController()
        {
            
        }
        
        public void ShowStage()
        {
            throw new NotImplementedException();
        }

        public void HideStage()
        {
            throw new NotImplementedException();
        }
    }
}