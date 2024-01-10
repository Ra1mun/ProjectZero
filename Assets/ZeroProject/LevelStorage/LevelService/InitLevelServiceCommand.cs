using System;
using ZeroProject.Bootstrap.Interfaces;

namespace ZeroProject.LevelStorage.LevelService
{
    public class InitLevelServiceCommand : ICommand
    {
        private readonly LevelService _levelService;
        public Action Done { get; set; }

        public InitLevelServiceCommand(LevelService levelService)
        {
            _levelService = levelService;
        }
        
        public void Execute()
        {
            _levelService.LoadLevels();
            _levelService.InitLevels();
            
            Done?.Invoke();
        }
    }
}