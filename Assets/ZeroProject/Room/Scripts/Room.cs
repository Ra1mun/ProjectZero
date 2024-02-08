using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroProject.Room
{
    public abstract class Room : MonoBehaviour
    {
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
}

