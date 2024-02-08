using UnityEngine;

namespace ZeroProject.Level
{
    public class LevelRoot : MonoBehaviour
    {
        public Transform Container => container;
        public Transform PoolContainer => poolContainer;
        
        [SerializeField] private Transform container;
        [SerializeField] private Transform poolContainer;
    }
}