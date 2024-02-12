using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroProject.Room
{
    public abstract class Room : MonoBehaviour
    {
        public TransitionPoints TransitionPoints;
        public abstract void Show();
        public abstract void Hide();
    }

    public enum RoomType
    {
        Battle,
        Boss,
        Enter,
        Treasure,
        Shop,
    }

    [Serializable]
    public class TransitionPoints
    {
        public Transform PreviousRoomPoint => previousRoomPoint;
        public Transform NextRoomPoint => nextRoomPoint;
        
        [SerializeField] private Transform previousRoomPoint;
        [SerializeField] private Transform nextRoomPoint;
    }
}

