using System;
using InputSystem.Interfaces;
using ZeroProject.InputSystem.Realisation;

namespace ZeroProject.InputSystem
{
    public class KeyboardInputSystem
    {
        public Action<float> OnDirectionMove;
        public Action OnJump;
        
        private readonly KeyboardMoveInput _keyboardMoveInput;
        private readonly KeyboardJumpActionInput _keyboardJumpActionInput;
        
        public KeyboardInputSystem(
            KeyboardMoveInput keyboardMoveInput,
            KeyboardJumpActionInput keyboardJumpActionInput)
        {
            _keyboardMoveInput = keyboardMoveInput;
            _keyboardJumpActionInput = keyboardJumpActionInput;
        }

        public void EnableInput()
        {
            _keyboardMoveInput.OnInput += DirectionMove;
            _keyboardJumpActionInput.OnInput += JumpAction;
            
            _keyboardMoveInput.Enable();
            _keyboardJumpActionInput.Enable();
        }

        private void DirectionMove(float direction)
        {
            OnDirectionMove?.Invoke(direction);
        }

        private void JumpAction()
        {
            OnJump?.Invoke();
        }

        public void DisableInput()
        {
            _keyboardMoveInput.OnInput -= DirectionMove;
            _keyboardJumpActionInput.OnInput -= JumpAction;
            
            _keyboardMoveInput.Disable();
            _keyboardJumpActionInput.Disable();
        }
    }
}