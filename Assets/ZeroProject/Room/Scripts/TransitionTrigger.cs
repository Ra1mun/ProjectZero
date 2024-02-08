using System;
using UnityEngine;

namespace ZeroProject.Room
{
    public class TransitionTrigger : MonoBehaviour
    {
        public event Action OnTriggerEnter;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<Player.Player>())
            {
                OnTriggerEnter?.Invoke();
            }
        }
    }
}