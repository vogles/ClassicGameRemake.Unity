using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private UIDocument _document;
    private Button _pongButton;
    private Button _doodleJumpButton;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _pongButton = _document.rootVisualElement.Q<Button>("startPongGame");
        _doodleJumpButton = _document.rootVisualElement.Q<Button>("startDoodleJumpGame");

        if (_pongButton != null)
        {
            _pongButton.clicked += OnPlayPong;
        }

        if (_doodleJumpButton != null)
        {
            _doodleJumpButton.clicked += OnDoodleJump;
        }
    }

    public void OnPlayPong()
    {
        SceneManager.LoadScene("Pong", LoadSceneMode.Single);
    }

    private void OnDoodleJump()
    {
        SceneManager.LoadScene("Breakout", LoadSceneMode.Single);
    }
}
