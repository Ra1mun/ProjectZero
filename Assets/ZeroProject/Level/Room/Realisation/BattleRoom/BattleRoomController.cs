using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class BattleRoomController : IRoomController
    {
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;
        
        private readonly LevelController _levelController;
        private readonly BattleRoom _battleRoom;
        
        public BattleRoomController(BattleRoom battleRoom,
            LevelController levelController)
        {
            _battleRoom = battleRoom;
            _levelController = levelController;
        }

        public void ShowRoom()
        {
            _levelController.Show(_battleRoom);
            
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
            
            _levelController.Hide(_battleRoom);
        }
    }
}