﻿using UnityEngine;

namespace ZeroProject.Camera
{
    public class CameraView : SceneObject.Realisation.SceneObject
    {
        public UnityEngine.Camera Camera => camera; 
        [SerializeField] private UnityEngine.Camera camera;
    }
}