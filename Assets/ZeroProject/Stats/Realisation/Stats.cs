using System;
using UnityEngine;
using ZeroProject.Stats.Interfaces;

namespace ZeroProject.Stats.Realisation
{
    public struct Stats
    {
        public int MaxHealth { get; set; }
        public int Damage { get; set; }
        public float AttackDistance { get; set; }

        public static Stats operator +(Stats a, Stats b)
        {
            return new Stats()
            {
                MaxHealth = a.MaxHealth + b.MaxHealth,
                Damage = a.Damage + b.Damage,
                AttackDistance = a.AttackDistance + b.AttackDistance,
            };
        }
    }
    
    [Serializable]
    public class CommonStats : IConifgStats
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _damage;
        [SerializeField] private float _attackDistance;
        
        public Stats GetStats()
        {
            return new Stats()
            {
                MaxHealth = _maxHealth,
                Damage = _damage,
                AttackDistance = _attackDistance,
            };
        }
    }
}