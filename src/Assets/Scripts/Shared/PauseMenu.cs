using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private UIDocument _document = null;
    private Button _continueButton = null;
    private Button _exitButton = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _continueButton = _document.rootVisualElement.Q<Button>("ContinueButton");
        _exitButton = _document.rootVisualElement.Q<Button>("ExitButton");

        if (_continueButton != null)
            _continueButton.clicked += OnContinue;

        if (_exitButton != null)
            _exitButton.clicked += OnExit;
    }

    private void OnContinue()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }

    private void OnExit()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
