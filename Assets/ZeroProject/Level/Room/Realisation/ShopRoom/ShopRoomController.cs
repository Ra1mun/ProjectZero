using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class ShopRoomController : IRoomController
    {
        
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;

        private readonly ShopRoom _shopRoom;
        private readonly LevelController _levelController;

        public ShopRoomController(
            ShopRoom shopRoom,
            LevelController levelController)
        {
            _shopRoom = shopRoom;
            _levelController = levelController;
        }
        
        public void ShowRoom()
        {
            _levelController.Show(_shopRoom);
            
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
            
            _levelController.Hide(_shopRoom);
        }
    }
}