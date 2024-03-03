using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class BattleRoomController : IRoomController
    {
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;
        
        private readonly LevelService _levelService;
        private readonly BattleRoom _battleRoom;
        
        public BattleRoomController(BattleRoom battleRoom,
            LevelService levelService)
        {
            _battleRoom = battleRoom;
            _levelService = levelService;
        }

        public void ShowRoom()
        {
            _levelService.Show(_battleRoom.GetInstanceID());
            
            _battleRoom.OnNextRoomTriggerEnteredEvent += OnNextRoomEnter;
            _battleRoom.OnPreviousRoomTriggerEnteredEvent += OnPreviousRoomEnter;
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
            _battleRoom.OnNextRoomTriggerEnteredEvent -= OnNextRoomEnter;
            _battleRoom.OnPreviousRoomTriggerEnteredEvent -= OnPreviousRoomEnter;
            
            _levelService.Hide(_battleRoom.GetInstanceID());
        }
    }
}