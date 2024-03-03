using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class TreasureRoomController : IRoomController
    {
        private readonly LevelService _levelService;
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;
        
        private readonly TreasureRoom _treasureRoom;
        

        public TreasureRoomController(
            TreasureRoom treasureRoom,
            LevelService levelService)
        {
            _treasureRoom = treasureRoom;
            _levelService = levelService;
        }

        public void ShowRoom()
        {
            _levelService.Show(_treasureRoom.GetInstanceID());
            
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
            
            _levelService.Hide(_treasureRoom.GetInstanceID());
        }
    }
}