using System;
using UnityEngine;

namespace InputSystem.Interfaces
{
    public interface IMoveInput
    {
        Action<float> OnInput { get; set; }
    }
}
