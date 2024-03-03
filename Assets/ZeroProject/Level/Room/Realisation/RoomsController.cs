using System.Collections.Generic;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class RoomsController
    {
        private readonly LinkedList<IRoomController> _roomControllers = new LinkedList<IRoomController>();
        
        public void ShowFirstRoom()
        {
            _roomControllers.First?.Value.ShowRoom();
        }
        
        public void SetupRoom(IRoomController roomController)
        {
            if (_roomControllers.Last != null)
            {
                _roomControllers.Last.Value.GoToNextRoom += roomController.ShowRoom;

                roomController.GoToPreviousRoom += _roomControllers.Last.Value.ShowRoom;
            }

            _roomControllers.AddLast(roomController);
        }
    }
}