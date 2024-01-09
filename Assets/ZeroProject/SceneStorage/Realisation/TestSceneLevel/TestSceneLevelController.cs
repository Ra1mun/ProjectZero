using ZeroProject.SceneStorage.Interfaces;

namespace ZeroProject.SceneStorage.Realisation.TestSceneLevel
{
    public class TestSceneLevelController : ISceneController
    {
        private readonly SceneService _sceneService;
        private readonly Scene _testScene;

        public TestSceneLevelController(SceneService sceneService)
        {
            _sceneService = sceneService;

            _testScene = _sceneService.Get<TestScene>();
        }
        
        public void ShowScene()
        {
            _sceneService.Show<TestScene>();
        }

        public void HideScene()
        {
            _sceneService.Hide<TestScene>();
        }
    }
}