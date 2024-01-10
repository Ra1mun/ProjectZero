using System;
using System.Collections.Generic;
using ZeroProject.Bootstrap.Interfaces;

namespace ZeroProject.Bootstrap
{
    public class ProcessingCommand
    {
        public event Action AllCommandDone;
        public bool IsExecuting { get; protected set; }
        public Queue<ICommand> Queue => _queue;

        private readonly Queue<ICommand> _queue = new Queue<ICommand>();

        protected int Count => _queue.Count;

        public void AddCommand(ICommand command)
        {
            if (command == null)
            {
                return;
            }
            
            _queue.Enqueue(command);
        }

        protected ICommand Dequeue()
        {
            return Count > 0 ? _queue.Dequeue() : null;
        }

        protected void OnComplete()
        {
            AllCommandDone?.Invoke();
        }
    }
}