using System;
using UnityEngine;

namespace ZeroProject.Room.EnterRoom
{
    public class EnterRoom : Room
    {
        public event Action GoToNextRoomEvent;
        public event Action GoToPreviousRoomEvent;
        
        [SerializeField] private TransitionTrigger previousTriggerTrigger;
        [SerializeField] private TransitionTrigger nextTriggerTrigger;
        
        public override void Show()
        {
            nextTriggerTrigger.OnTriggerEnter += GoToNext;
            previousTriggerTrigger.OnTriggerEnter += GoToPrevious;
        }
        
        private void GoToNext()
        {
            GoToNextRoomEvent?.Invoke();
        }

        private void GoToPrevious()
        {
            GoToPreviousRoomEvent?.Invoke();
        }

        public override void Hide()
        {
            nextTriggerTrigger.OnTriggerEnter -= GoToNext;
            previousTriggerTrigger.OnTriggerEnter -= GoToPrevious;
        }
    }
}