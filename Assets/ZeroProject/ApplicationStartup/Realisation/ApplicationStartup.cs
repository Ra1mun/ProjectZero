using Unity.VisualScripting;
using Zenject;
using ZeroProject.Camera;
using ZeroProject.UI.Realisation;

namespace ZeroProject.ApplicationStartup.Realisation
{
    public class ApplicationStartup
    {
        public event System.Action OnStartInit;
        public event System.Action OnEndInit;
        
        private readonly IInstantiator _instantiator;
        private Bootstrap.Bootstrap _bootstrap;

        public ApplicationStartup(IInstantiator instantiator)
        {
            _instantiator = instantiator;

            StartBootstrap();
        }
        private void StartBootstrap()
        {
            OnStartInit?.Invoke();
            
            _bootstrap = new Bootstrap.Bootstrap();

            _bootstrap.AddCommand(_instantiator.Instantiate<InitCameraCommand>());
            _bootstrap.AddCommand(_instantiator.Instantiate<InitUIPanelCommand>());

            _bootstrap.AllCommandDone += Start;

            _bootstrap.StartExecute();
        }

        private void Start()
        {
            _bootstrap.AllCommandDone -= Start;
            _instantiator.Instantiate<InitApplicationCommand>()
                .Execute();
            
            OnEndInit?.Invoke();
        }
    }
}