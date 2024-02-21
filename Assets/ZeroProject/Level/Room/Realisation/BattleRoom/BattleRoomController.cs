using System;
using ZeroProject.Room.Interfaces;

namespace ZeroProject.Level.Room.Realisation
{
    public class BattleRoomController : IRoomController
    {
        public event Action GoToNextRoom;
        public event Action GoToPreviousRoom;
        
        private LevelController _levelController;
        
        private readonly BattleRoom _battleRoom;
        
        public BattleRoomController(BattleRoom battleRoom)
        {
            _battleRoom = battleRoom;
        }

        public void Initialize(LevelController levelController)
        {
            _levelController = levelController;
        }
        
        public void ShowRoom()
        {
            _levelController.Show(_battleRoom);
            
            _battleRoom.OnNextRoomTriggerEnteredEvent += OnNextRoomEnter;
            _battleRoom.OnNextRoomTriggerEnteredEvent += OnPreviousRoomEnter;
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
            _battleRoom.OnNextRoomTriggerEnteredEvent -= OnPreviousRoomEnter;
            
            _levelController.Hide(_battleRoom);
        }
    }
}