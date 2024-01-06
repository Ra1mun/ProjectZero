using UnityEngine;

namespace ZeroProject.SceneStorage
{
    public abstract class Scene : MonoBehaviour
    {
        public abstract void ShowScene();
        
        public abstract void HideScene();
    }
}