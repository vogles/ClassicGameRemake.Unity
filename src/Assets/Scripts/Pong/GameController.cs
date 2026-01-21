using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public enum GameState
    {
        Idle,
        Playing,
        LeftWon,
        RightWon,
    }

    [SerializeField] private Ball _ball;
    [SerializeField] private GameObject _pauseMenuPrefab;

    private GameState _state;
    private int _player1Score = 0;
    private int _player2Score = 0;
    private PlayerControls _playerControls;

    public int Player1Score => _player1Score;
    public int Player2Score => _player2Score;

    // Start is called before the first frame update
    private void Awake()
    {
        ChangeState(GameState.Idle);
     
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        if (_playerControls != null)
        {
            _playerControls.Enable();
            _playerControls.PongGameplay.StartGame.performed += OnStartGame;
            _playerControls.PongGameplay.Pause.performed += OnPauseGame;
        }
    }

    private void OnDisable()
    {
        if (_playerControls != null)
        {
            _playerControls.PongGameplay.StartGame.performed -= OnStartGame;
            _playerControls.PongGameplay.Pause.performed -= OnPauseGame;
            _playerControls.Disable();
        }
    }

    public void ChangeState(GameState state)
    {
        if (state == _state)
        {
            return;
        }

        switch (state)
        {
            case GameState.Idle:
                _ball.Position = Vector2.zero;
                _ball.Direction = Vector2.zero;
                break;
            case GameState.Playing:
                var directionX = Random.value < 0.5f ? -1 : 1;
                var directionY = Random.value < 0.5f ? -0.75f : 0.75f;
                _ball.Direction = new Vector2(directionX, directionY);
                break;
            case GameState.LeftWon:
                _ball.Position = Vector2.zero;
                _ball.Direction = Vector2.zero;
                _player1Score++;
                break;
            case GameState.RightWon:
                _ball.Position = Vector2.zero;
                _ball.Direction = Vector2.zero;
                _player2Score++;
                break;
        }

        _state = state;
    }

    private void OnStartGame(InputAction.CallbackContext context)
    {
        ChangeState(GameController.GameState.Playing);
    }

    private void OnPauseGame(InputAction.CallbackContext context)
    {
        if (_pauseMenuPrefab != null)
        {
            var pauseMenu = Instantiate(_pauseMenuPrefab);
            Time.timeScale = 0f;
        }
    }
}
