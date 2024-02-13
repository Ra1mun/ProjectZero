using System;
using UnityEngine;

namespace ZeroProject.Level.Room.Realisation
{
    public class BattleRoom : Room
    {
        public TransitionTrigger PreviousRoomPoint => previousTriggerTrigger;
        public TransitionTrigger NextRoomPoint => nextTriggerTrigger;
        
        [SerializeField] private TransitionTrigger previousTriggerTrigger;
        [SerializeField] private TransitionTrigger nextTriggerTrigger;
        
        public override void Show()
        {
            throw new NotImplementedException();
        }

        public override void Hide()
        {
            throw new NotImplementedException();
        }
    }
}