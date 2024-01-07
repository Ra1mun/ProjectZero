using UnityEngine;

namespace ZeroProject.LevelStorage.LevelService
{
    public abstract class Level : MonoBehaviour
    {
        public abstract void ShowScene();
        
        public abstract void HideScene();
    }
}