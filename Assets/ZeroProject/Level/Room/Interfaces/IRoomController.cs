using System;
using UnityEngine.PlayerLoop;
using ZeroProject.Level;

namespace ZeroProject.Room.Interfaces
{
    public interface IRoomController
    {
        event Action GoToNextRoom;
        event Action GoToPreviousRoom;
        
        void ShowRoom();
        void HideRoom();
    }
}