using System;
using InputSystem.Interfaces;
using UnityEngine;
using Zenject;

namespace ZeroProject.InputSystem.Realisation
{
    public class KeyboardJumpActionInput : IActionInput, ITickable
    {
        private readonly TickableManager _tickableManager;
        public Action OnInput { get; set; }

        private bool _isActive;

        public KeyboardJumpActionInput(TickableManager tickableManager)
        {
            _tickableManager = tickableManager;
        }
        
        public void Enable()
        {
            if (!_isActive)
            {
                _tickableManager.Add(this);
                _isActive = true;
            }
        }
        
        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnInput.Invoke();
            }
        }

        public void Disable()
        {
            if (_isActive)
            {
                _tickableManager.Remove(this);
                _isActive = false;
            }
        }
    }
}