using System;
using UnityEngine;

namespace ZeroProject.Level.Room
{
    public class TransitionTrigger : MonoBehaviour
    {
        public event Action OnTriggerEnter;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Player.Player>())
            {
                OnTriggerEnter?.Invoke();
            }
        }
    }
}