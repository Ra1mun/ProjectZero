using UnityEngine;

namespace ZeroProject.Camera
{
    public class CameraView
    {
        public UnityEngine.Camera Camera => camera; 
        [SerializeField] private UnityEngine.Camera camera;
    }
}