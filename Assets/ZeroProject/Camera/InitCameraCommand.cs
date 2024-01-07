using System;
using ZeroProject.Bootstrap.Interfaces;
using ZeroProject.SceneObject.Realisation;
using ZeroProject.UI.Realisation;

namespace ZeroProject.Camera
{
    public class InitCameraCommand : ICommand
    {
        private readonly UIRoot _uiRoot;
        private readonly SceneObjectStorage _sceneObjectStorage;
        public Action Done { get; set; }

        public InitCameraCommand(UIRoot uiRoot, SceneObjectStorage sceneObjectStorage)
        {
            _uiRoot = uiRoot;
            _sceneObjectStorage = sceneObjectStorage;
        }
        
        public void Execute()
        {
            var cameraView = _sceneObjectStorage.CreateAndAdd<CameraView>("CameraView");

            _uiRoot.Canvas.worldCamera = cameraView.Camera;
            
            Done?.Invoke();
        }
    }
}