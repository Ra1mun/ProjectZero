using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class EnterRoomController : IRoomController
    {
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;

        private readonly EnterRoom _enterRoom;
        private readonly LevelController _levelController;

        public EnterRoomController(
            EnterRoom enterRoom,
            LevelController levelController)
        {
            _enterRoom = enterRoom;
            _levelController = levelController;
        }
        
        public void ShowRoom()
        {
            _levelController.Show(_enterRoom);
            
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
            
            _levelController.Hide(_enterRoom);
        }
    }
}