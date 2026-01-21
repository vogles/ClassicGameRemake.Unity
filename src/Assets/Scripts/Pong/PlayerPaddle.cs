using UnityEngine;
using UnityEngine.InputSystem;

namespace ClassicGames.Pong
{
    public class PlayerPaddle : Paddle
    {
        private PlayerControls _playerControls;

        protected override void Awake()
        {
            _playerControls = new PlayerControls();

            base.Awake();
        }

        private void OnEnable()
        {
            if (_playerControls != null)
            {
                _playerControls.Enable();
                _playerControls.PongGameplay.Move.canceled += OnMoveCancelled;
                _playerControls.PongGameplay.Move.performed += OnMove;
            }
        }

        private void OnDisable()
        {
            if (_playerControls != null)
            {
                _playerControls.PongGameplay.Move.canceled -= OnMoveCancelled;
                _playerControls.PongGameplay.Move.performed -= OnMove;
                _playerControls.Disable();
            }
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            var moveDirection = context.ReadValue<Vector2>();
            moveDirection.x = 0;
            Direction = moveDirection;
        }

        private void OnMoveCancelled(InputAction.CallbackContext context)
        {
            Direction = Vector2.zero;
        }
    }
}

