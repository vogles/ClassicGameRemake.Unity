using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    private GameController _gameController = null;
    private UIDocument _document = null;
    private Label _player1ScoreLabel = null;
    private Label _player2ScoreLabel = null;

    private void Awake()
    {
        _gameController = Object.FindAnyObjectByType<GameController>();
        _document = GetComponent<UIDocument>();
        _player1ScoreLabel = _document.rootVisualElement.Q<Label>("player1Score");
        _player2ScoreLabel = _document.rootVisualElement.Q<Label>("player2Score");
    }

    private void Update()
    {
        if (_gameController == null)
        {
            return;
        }
        
        if (_player1ScoreLabel != null)
        {
            _player1ScoreLabel.text = $"{_gameController.Player1Score}";
        }

        if (_player2ScoreLabel != null)
        {
            _player2ScoreLabel.text = $"{_gameController.Player2Score}";
        }
    }
}
