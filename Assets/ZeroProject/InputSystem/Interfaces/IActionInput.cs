using System;

namespace InputSystem.Interfaces
{
    public interface IActionInput
    { 
        Action OnInput { get; set; }
    }
}