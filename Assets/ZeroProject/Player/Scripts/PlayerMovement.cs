using UnityEngine;
using ZeroProject.InputSystem;
using ZeroProject.Player.Jump;
using ZeroProject.Player.Jump.Realisation;

namespace Player.Scripts
{
    public class PlayerMovement
    {
        private readonly KeyboardInputSystem _input;
        private readonly Player _player;
        private readonly DevelopmentSettings _developmentSettings;
        private readonly JumpDirection _jumpDirection;

        private Vector2 _direction;

        public PlayerMovement(KeyboardInputSystem input,
            Player player,
            DevelopmentSettings developmentSettings)
        {
            _input = input;
            _player = player;
            _developmentSettings = developmentSettings;

            _jumpDirection = new JumpNormalizedDirection();
        }

        private void Enable()
        {
            _input.OnDirectionMove += Move;
            _input.OnJump += Jump;
        
            _input.EnableInput();
        }

        private void Move(float direction)
        {
            _direction = new Vector3(direction, 0, 0);
            
            _player
                .Rigidbody
                .MovePosition(_player.Origin.position + (Vector3)_direction);
        }

        private void Jump()
        {
            if (isGrounded())
            {
                _player
                    .Rigidbody
                    .AddForce(_jumpDirection.Direction(_direction) * _developmentSettings.JumpForce);
            }
        }

        private bool isGrounded()
        {
            return true;
        }

        private void Disable()
        {
            _input.OnDirectionMove += Move;
            _input.OnJump += Jump;
        
            _input.EnableInput();
        }
    }
}
