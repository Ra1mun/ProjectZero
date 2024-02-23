using System;
using UnityEngine;
using ZeroProject.Stats.Interfaces;

namespace ZeroProject.Stats.Realisation
{
    public struct ItemStats
    {
        public int Damage { get; set; }
        public float AttackDistance { get; set; }
        public float AttackSpeed { get; set; }

        public static ItemStats operator +(ItemStats a, ItemStats b)
        {
            return new ItemStats()
            {
                Damage = a.Damage + b.Damage,
                AttackDistance = a.AttackDistance + b.AttackDistance,
                AttackSpeed = a.AttackSpeed + b.AttackSpeed,
            };
        }
    }
    
    [Serializable]
    public class ItemCommonStats : IItemConfigStats
    {
        [SerializeField] private int damage;
        [SerializeField] private float attackDistance;
        [SerializeField] private float attackSpeed;
        
        public ItemStats GetStats()
        {
            return new ItemStats()
            {
                Damage = damage,
                AttackDistance = attackDistance,
                AttackSpeed = attackSpeed,
            };
        }
    }
}