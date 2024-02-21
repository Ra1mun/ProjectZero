using System;
using UnityEngine;

namespace ZeroProject.Level.Room.Realisation
{
    public class ShopRoom : Room
    {
        public event Action OnNextRoomTriggerEnteredEvent;
        public event Action OnPreviousRoomTriggerEnteredEvent;
        
        [SerializeField] private TransitionTrigger previousRoomTrigger;
        [SerializeField] private TransitionTrigger nextRoomTrigger;
        
        public override void Show()
        {
            nextRoomTrigger.OnTriggerEnter += OnNextRoomTriggerEntered;
            previousRoomTrigger.OnTriggerEnter += OnPreviousRoomTriggerEntered;
        }

        private void OnNextRoomTriggerEntered()
        {
            OnNextRoomTriggerEnteredEvent?.Invoke();
        }
        
        private void OnPreviousRoomTriggerEntered()
        {
            OnPreviousRoomTriggerEnteredEvent?.Invoke();
        }

        public override void Hide()
        {
            nextRoomTrigger.OnTriggerEnter -= OnNextRoomTriggerEntered;
            previousRoomTrigger.OnTriggerEnter -= OnPreviousRoomTriggerEntered;
        }
    }
}