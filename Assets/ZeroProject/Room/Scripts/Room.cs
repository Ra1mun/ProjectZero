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
        public Transform EnterPoint => enterPoint;
        public List<Transform> TransitPoints => transitPoints;
        
        [SerializeField] private Transform enterPoint;
        [SerializeField] private List<Transform> transitPoints;
    }
}

