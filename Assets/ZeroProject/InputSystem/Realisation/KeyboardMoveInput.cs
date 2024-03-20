using System;
using InputSystem.Interfaces;
using UnityEngine;
using Zenject;

namespace ZeroProject.InputSystem.Realisation
{
    public class KeyboardMoveInput : IMoveInput, ITickable
    {
        public Action<float> OnInput { get; set; }
        
        private readonly TickableManager _tickableManager;

        private bool _isActive;
        
        public KeyboardMoveInput(TickableManager tickableManager)
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
            OnInput.Invoke(Input.GetAxis("Horizontal"));
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