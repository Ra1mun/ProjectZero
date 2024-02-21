using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class BossRoomController : IRoomController
    {
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;

        private readonly BossRoom _bossRoom;
        private readonly LevelController _levelController;

        public BossRoomController(
            BossRoom bossRoom,
            LevelController levelController)
        {
            _bossRoom = bossRoom;
            _levelController = levelController;
        }
        

        public void ShowRoom()
        {
            _levelController.Show(_bossRoom);
            
            _bossRoom.OnNextRoomTriggerEnteredEvent += OnNextRoomEnter;
            _bossRoom.OnPreviousRoomTriggerEnteredEvent += OnPreviousRoomEnter;
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
            _bossRoom.OnNextRoomTriggerEnteredEvent -= OnNextRoomEnter;
            _bossRoom.OnPreviousRoomTriggerEnteredEvent -= OnPreviousRoomEnter;
            
            _levelController.Hide(_bossRoom);
        }
    }
}