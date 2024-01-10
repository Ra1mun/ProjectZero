using ZeroProject.LevelStorage.LevelService;
using ZeroProject.SceneStorage.Interfaces;

namespace ZeroProject.SceneStorage.Realisation.TestSceneLevel
{
    public class TestLevelController : ILevelController
    {
        private readonly LevelService _levelService;
        private readonly Level _testLevel;

        public TestLevelController(LevelService levelService)
        {
            _levelService = levelService;

            _testLevel = _levelService.Get<TestLevel>();
        }
        
        public void ShowScene()
        {
            _levelService.Show<TestLevel>();
        }

        public void HideScene()
        {
            _levelService.Hide<TestLevel>();
        }
    }
}