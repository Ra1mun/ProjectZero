using System;

namespace ZeroProject.Room.Interfaces
{
    public interface IRoomController
    {
        event Action GoToNextRoom;
        event Action GoToPreviousRoom;
        
        int ID { get; set; }
        
        void ShowRoom();
        void HideRoom();
    }
}