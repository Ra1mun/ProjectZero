using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class EnterRoomController : IRoomController
    {
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;

        private readonly EnterRoom _enterRoom;
        private readonly LevelService _levelService;

        public EnterRoomController(
            EnterRoom enterRoom,
            LevelService levelService)
        {
            _enterRoom = enterRoom;
            _levelService = levelService;
        }
        
        public void ShowRoom()
        {
            _levelService.Show(_enterRoom.GetInstanceID());
            
            _enterRoom.OnNextRoomTriggerEnteredEvent += OnNextRoomEnter;
            _enterRoom.OnPreviousRoomTriggerEnteredEvent += OnPreviousRoomEnter;
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
            _enterRoom.OnNextRoomTriggerEnteredEvent -= OnNextRoomEnter;
            _enterRoom.OnPreviousRoomTriggerEnteredEvent -= OnPreviousRoomEnter;
            
            _levelService.Hide(_enterRoom.GetInstanceID());
        }
    }
}