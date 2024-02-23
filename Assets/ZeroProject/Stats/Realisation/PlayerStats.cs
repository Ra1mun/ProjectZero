using System;
using UnityEngine;
using ZeroProject.Stats.Interfaces;

namespace ZeroProject.Stats.Realisation
{
    public struct PlayerStats
    {
        public int MaxHealth { get; set; }
        public float MoveSpeed { get; set; }

        public static PlayerStats operator +(PlayerStats a, PlayerStats b)
        {
            return new PlayerStats()
            {
                MaxHealth = a.MaxHealth + b.MaxHealth,
                MoveSpeed = a.MoveSpeed + b.MoveSpeed,
            };
        }
    }
    
    [Serializable]
    public class PlayerCommonStats : IPlayerConfigStats
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private float _moveSpeed;

        public PlayerStats GetStats()
        {
            return new PlayerStats()
            {
                MaxHealth = _maxHealth,
                MoveSpeed = _moveSpeed,
            };
        }
    }
}