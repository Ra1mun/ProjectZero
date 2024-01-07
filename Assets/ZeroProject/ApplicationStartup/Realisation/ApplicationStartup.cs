using Zenject;
using ZeroProject.Camera;
using ZeroProject.LevelStorage.LevelService;
using ZeroProject.UI.Realisation;

namespace ZeroProject.ApplicationStartup.Realisation
{
    public class ApplicationStartup
    {
        private readonly IInstantiator _instantiator;

        public ApplicationStartup(IInstantiator instantiator)
        {
            _instantiator = instantiator;

            StartBootstrap();
        }
        private void StartBootstrap()
        {
            var bootstrap = new Bootstrap.Bootstrap();
            
            bootstrap.AddCommand(_instantiator.Instantiate<InitLevelServiceCommand>());
            bootstrap.AddCommand(_instantiator.Instantiate<InitCameraCommand>());

            bootstrap.StartExecute();
        }
    }
}