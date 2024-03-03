using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class ShopRoomController : IRoomController
    {
        
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;

        private readonly ShopRoom _shopRoom;
        private readonly LevelService _levelService;

        public ShopRoomController(
            ShopRoom shopRoom,
            LevelService levelService)
        {
            _shopRoom = shopRoom;
            _levelService = levelService;
        }
        
        public void ShowRoom()
        {
            _levelService.Show(_shopRoom.GetInstanceID());
            
            _shopRoom.OnNextRoomTriggerEnteredEvent += OnNextRoomEnter;
            _shopRoom.OnPreviousRoomTriggerEnteredEvent += OnPreviousRoomEnter;
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
            _shopRoom.OnNextRoomTriggerEnteredEvent -= OnNextRoomEnter;
            _shopRoom.OnPreviousRoomTriggerEnteredEvent -= OnPreviousRoomEnter;
            
            _levelService.Hide(_shopRoom.GetInstanceID());
        }
    }
}