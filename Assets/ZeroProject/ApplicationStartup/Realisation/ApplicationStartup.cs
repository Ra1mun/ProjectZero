using Zenject;

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
            
            bootstrap.StartExecute();
        }
    }
}