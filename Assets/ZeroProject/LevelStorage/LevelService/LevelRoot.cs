using UnityEngine;

namespace ZeroProject.SceneStorage
{
    public class LevelRoot : MonoBehaviour
    {
        public Transform PoolContainer => poolContainer;
        public Transform Container => container;
        
        [SerializeField] private Transform poolContainer;
        [SerializeField] private Transform container;
    }
}