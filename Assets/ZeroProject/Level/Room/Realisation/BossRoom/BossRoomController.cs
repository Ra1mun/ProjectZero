using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class BossRoomController : IRoomController
    {
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;

        private readonly BossRoom _bossRoom;
        private readonly LevelService _levelService;

        public BossRoomController(
            BossRoom bossRoom,
            LevelService levelService)
        {
            _bossRoom = bossRoom;
            _levelService = levelService;
        }
        

        public void ShowRoom()
        {
            _levelService.Show(_bossRoom.GetInstanceID());
            
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
            
            _levelService.Hide(_bossRoom.GetInstanceID());
        }
    }
}