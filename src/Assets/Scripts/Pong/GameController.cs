using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private GameState _state;
    private int _player1Score = 0;
    private int _player2Score = 0;

    public int Player1Score => _player1Score;
    public int Player2Score => _player2Score;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(GameState.Idle);
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
}
