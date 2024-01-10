using System;

namespace ZeroProject.Bootstrap.Interfaces
{
    public interface ICommand
    {
        Action Done { get; set; }
        void Execute();
    }
}