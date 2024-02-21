using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class TreasureRoomController : IRoomController
    {
        private readonly LevelController _levelController;
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;
        
        private readonly TreasureRoom _treasureRoom;
        

        public TreasureRoomController(
            TreasureRoom treasureRoom,
            LevelController levelController)
        {
            _treasureRoom = treasureRoom;
            _levelController = levelController;
        }

        public void ShowRoom()
        {
            _levelController.Show(_treasureRoom);
            
            _treasureRoom.OnNextRoomTriggerEnteredEvent += OnNextRoomEnter;
            _treasureRoom.OnPreviousRoomTriggerEnteredEvent += OnPreviousRoomEnter;
        }

        private void OnNextRoomEnter()
        {
            GoToNextRoom?.Invoke();
            
            HideRoom();
        }

        private void OnPreviousRoomEnter()
        {
            GoToPreviousRoom?.Invoke();
            
            HideRoom();
        }

        public void HideRoom()
        {
            _treasureRoom.OnNextRoomTriggerEnteredEvent -= OnNextRoomEnter;
            _treasureRoom.OnPreviousRoomTriggerEnteredEvent -= OnPreviousRoomEnter;
            
            _levelController.Hide(_treasureRoom);
        }
    }
}