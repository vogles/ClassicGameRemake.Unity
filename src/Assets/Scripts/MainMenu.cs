using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private UIDocument _document;
    private Button _pongButton;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _pongButton = _document.rootVisualElement.Q<Button>("startPongGame");

        if (_pongButton != null)
        {
            _pongButton.clicked += OnPlayPong;
        }
    }

    public void OnPlayPong()
    {
        SceneManager.LoadScene("Pong", LoadSceneMode.Single);
    }
}
