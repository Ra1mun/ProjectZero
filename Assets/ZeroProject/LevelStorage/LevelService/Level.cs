using UnityEngine;

namespace ZeroProject.SceneStorage
{
    public abstract class Level : MonoBehaviour
    {
        public abstract void ShowScene();
        
        public abstract void HideScene();
    }
}