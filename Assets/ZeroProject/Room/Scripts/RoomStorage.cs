using System.Collections.Generic;
using UnityEngine;
using ZeroProject.Room.Realisation;

namespace ZeroProject.Room
{
    public abstract class RoomStorage : ScriptableObject
    {
        [SerializeField] protected BattleRoom[] battleRooms;
        [SerializeField] protected TreasureRoom[] treasureRooms;
        [SerializeField] protected EnterRoom enterRoom;
        [SerializeField] protected ShopRoom shopRoom;
        [SerializeField] protected BossRoom bossRoom;

        protected virtual void Initialize() { }

        public abstract Room GetRandomRoom();
        public abstract T GetRoom<T>() where T: Room;
    }
}
