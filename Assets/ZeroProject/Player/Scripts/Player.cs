using UnityEngine;

namespace Player.Scripts
{
    public class Player : MonoBehaviour
    {
        public Transform Origin => origin;
        public Rigidbody2D Rigidbody => rigidbody;
        
        [SerializeField] private Transform origin;
        [SerializeField] private new Rigidbody2D rigidbody;
    }
}