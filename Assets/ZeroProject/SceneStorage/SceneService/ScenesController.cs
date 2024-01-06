using System.Collections.Generic;
using ZeroProject.SceneStorage.Interfaces;

namespace ZeroProject.SceneStorage
{
    public class ScenesController
    {
        private LinkedList<ISceneController> _sceneControllers = new LinkedList<ISceneController>();

        public ScenesController()
        {
            
        }
        
        private void IncludeScene(ISceneController sceneController)
        {
            _sceneControllers.AddLast(sceneController);
        }
    }
}