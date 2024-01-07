﻿using System.Collections.Generic;
using ZeroProject.SceneStorage.Interfaces;

namespace ZeroProject.SceneStorage
{
    public class LevelsController
    {
        private LinkedList<ILevelController> _sceneControllers = new LinkedList<ILevelController>();

        public LevelsController()
        {
            
        }
        
        private void IncludeScene(ILevelController levelController)
        {
            _sceneControllers.AddLast(levelController);
        }
    }
}